    // Search for text holder
    Text textPlaceHolder = word_doc.MainDocumentPart.Document.Body.Descendants<Text>()
        .Where((x) => x.Text == "$image_tag$").First();
    if (textPlaceHolder == null)
    {
      Console.WriteLine("Text holder not found!");      
    }
    else
    {
      var parent = textPlaceHolder.Parent;
      if(!(parent is Run))  // Parent should be a run element.
      {
        Console.Out.WriteLine("Parent is not run");
      }
      else
      {
        // Insert image (the image created with your function) after text place holder.        
        textPlaceHolder.Parent.InsertAfter<Drawing>(element, textPlaceHolder);
        // Remove text place holder.
        textPlaceHolder.Remove();
      }
    }
