    private static void SetFormFieldValue(TextInput textInput, string value)
    {  // Code for http://stackoverflow.com/a/40081925/3103123
    
       if (value == null) // Reset formfield using default if set.
       {
          if (textInput.DefaultTextBoxFormFieldString != null && textInput.DefaultTextBoxFormFieldString.Val.HasValue)
             value = textInput.DefaultTextBoxFormFieldString.Val.Value;
       }
    
       // Enforce max length.
       short maxLength = 0; // Unlimited
       if (textInput.MaxLength != null && textInput.MaxLength.Val.HasValue)
          maxLength = textInput.MaxLength.Val.Value;
       if (value != null && maxLength > 0 && value.Length > maxLength)
          value = value.Substring(0, maxLength);
    
       // Not enforcing TextBoxFormFieldType (read documentation...).
       // Just note that the Word instance may modify the value of a formfield when user leave it based on TextBoxFormFieldType and Format.
       // A curious example:
       // Type Number, format "# ##0,00".
       // Set value to "2016 was the warmest year ever, at least since 1999.".
       // Open the document and select the field then tab out of it.
       // Value now is "2 016 tht,tt" (the logic behind this escapes me).
    
       // Format value. (Only able to handle formfields with textboxformfieldtype regular.)
       if (textInput.TextBoxFormFieldType != null
       && textInput.TextBoxFormFieldType.Val.HasValue
       && textInput.TextBoxFormFieldType.Val.Value != TextBoxFormFieldValues.Regular)
          throw new ApplicationException("SetFormField: Unsupported textboxformfieldtype, only regular is handled.\r\n" + textInput.Parent.OuterXml);
       if (!string.IsNullOrWhiteSpace(value)
       && textInput.Format != null
       && textInput.Format.Val.HasValue)
       {
          switch (textInput.Format.Val.Value)
          {
             case "Uppercase":
                value = value.ToUpperInvariant();
                break;
             case "Lowercase":
                value = value.ToLowerInvariant();
                break;
             case "First capital":
                value = value[0].ToString().ToUpperInvariant() + value.Substring(1);
                break;
             case "Title case":
                value = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
                break;
             default: // ignoring any other values (not supposed to be any)
                break;
          }
       }
    
       // Find run containing "separate" fieldchar.
       Run rTextInput = textInput.Ancestors<Run>().FirstOrDefault();
       if (rTextInput == null) throw new ApplicationException("SetFormField: Did not find run containing textinput.\r\n" + textInput.Parent.OuterXml);
       Run rSeparate = rTextInput.ElementsAfter().FirstOrDefault(ru =>
          ru.GetType() == typeof(Run)
          && ru.Elements<FieldChar>().FirstOrDefault(fc =>
             fc.FieldCharType == FieldCharValues.Separate)
             != null) as Run;
       if (rSeparate == null) throw new ApplicationException("SetFormField: Did not find run containing separate.\r\n" + textInput.Parent.OuterXml);
    
       // Find run containg "end" fieldchar.
       Run rEnd = rTextInput.ElementsAfter().FirstOrDefault(ru =>
          ru.GetType() == typeof(Run)
          && ru.Elements<FieldChar>().FirstOrDefault(fc =>
             fc.FieldCharType == FieldCharValues.End)
             != null) as Run;
       if (rEnd == null) // Formfield value contains paragraph(s)
       {
          Paragraph p = rSeparate.Parent as Paragraph;
          Paragraph pEnd = p.ElementsAfter().FirstOrDefault(pa =>
          pa.GetType() == typeof(Paragraph)
          && pa.Elements<Run>().FirstOrDefault(ru =>
             ru.Elements<FieldChar>().FirstOrDefault(fc =>
                fc.FieldCharType == FieldCharValues.End)
                != null)
             != null) as Paragraph;
          if (pEnd == null) throw new ApplicationException("SetFormField: Did not find paragraph containing end.\r\n" + textInput.Parent.OuterXml);
          rEnd = pEnd.Elements<Run>().FirstOrDefault(ru =>
             ru.Elements<FieldChar>().FirstOrDefault(fc =>
                fc.FieldCharType == FieldCharValues.End)
                != null);
       }
    
       // Remove any existing value.
    
       Run rFirst = rSeparate.NextSibling<Run>();
       if (rFirst == null || rFirst == rEnd)
       {
          RunProperties rPr = rTextInput.GetFirstChild<RunProperties>();
          if (rPr != null) rPr = rPr.CloneNode(true) as RunProperties;
          rFirst = rSeparate.InsertAfterSelf<Run>(new Run(new[] { rPr }));
       }
       rFirst.RemoveAllChildren<Text>();
    
       Run r = rFirst.NextSibling<Run>();
       while(r != rEnd)
       {
          if (r != null)
          {
             r.Remove();
             r = rFirst.NextSibling<Run>();
          }
          else // next paragraph
          {
             Paragraph p = rFirst.Parent.NextSibling<Paragraph>();
             if (p == null) throw new ApplicationException("SetFormField: Did not find next paragraph prior to or containing end.\r\n" + textInput.Parent.OuterXml);
             r = p.GetFirstChild<Run>();
             if (r == null)
             {
                // No runs left in paragraph, move other content to end of paragraph containing "separate" fieldchar.
                p.Remove();
                while (p.FirstChild != null)
                {
                   OpenXmlElement oxe = p.FirstChild;
                   oxe.Remove();
                   if (oxe.GetType() == typeof(ParagraphProperties)) continue;
                   rSeparate.Parent.AppendChild(oxe);
                }
             }
          }
       }
       if (rEnd.Parent != rSeparate.Parent)
       {
          // Merge paragraph containing "end" fieldchar with paragraph containing "separate" fieldchar.
          Paragraph p = rEnd.Parent as Paragraph;
          p.Remove();
          while (p.FirstChild != null)
          {
             OpenXmlElement oxe = p.FirstChild;
             oxe.Remove();
             if (oxe.GetType() == typeof(ParagraphProperties)) continue;
             rSeparate.Parent.AppendChild(oxe);
          }
       }
    
       // Set new value.
    
       if (value != null)
       {
          // Word API use \v internally for newline and \r for para. We treat \v, \r\n, and \n as newline (Break).
          string[] lines = value.Replace("\r\n", "\n").Split(new char[]{'\v', '\n', '\r'});
          string line = lines[0];
          Text text = rFirst.AppendChild<Text>(new Text(line));
          if (line.StartsWith(" ") || line.EndsWith(" ")) text.SetAttribute(new OpenXmlAttribute("xml:space", null, "preserve"));
          for (int i = 1; i < lines.Length; i++)
          {
             rFirst.AppendChild<Break>(new Break());
             line = lines[i];
             text = rFirst.AppendChild<Text>(new Text(lines[i]));
             if (line.StartsWith(" ") || line.EndsWith(" ")) text.SetAttribute(new OpenXmlAttribute("xml:space", null, "preserve"));
          }
       }
       else
       { // An empty formfield of type textinput got char 8194 times 5 or maxlength if maxlength is in the range 1 to 4.
          short length = maxLength;
          if (length == 0 || length > 5) length = 5;
          rFirst.AppendChild(new Text(((char)8194).ToString()));
          r = rFirst;
          for (int i = 1; i < length; i++) r = r.InsertAfterSelf<Run>(r.CloneNode(true) as Run);
       }
    }
