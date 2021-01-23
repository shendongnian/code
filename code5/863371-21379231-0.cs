    using iTextSharp.text.pdf;
    using iTextSharp.text;
  
    private void openPDF()
    {
        string str = "";
        string newFile = "c:\\New Document.pdf";
        Document doc = new Document();
  
        PdfReader reader = new PdfReader("c:\\New Document.pdf");
        for (int i = 1; i <= reader.NumberOfPages; i++)
        {
            byte[] bt = reader.GetPageContent(i);
            str += ExtractTextFromPDFBytes(bt);
        }
    }
  
    private string ExtractTextFromPDFBytes(byte[] input)
    {
        if (input == null || input.Length == 0) return "";
  
        try
        {
            string resultString = "";
  
            // Flag showing if we are we currently inside a text object
            bool inTextObject = false;
  
            // Flag showing if the next character is literal
            // e.g. '\\' to get a '\' character or '\(' to get '('
            bool nextLiteral = false;
  
            // () Bracket nesting level. Text appears inside ()
            int bracketDepth = 0;
  
            // Keep previous chars to get extract numbers etc.:
            char[] previousCharacters = new char[_numberOfCharsToKeep];
            for (int j = 0; j < _numberOfCharsToKeep; j++) previousCharacters[j] = ' ';
  
            for (int i = 0; i < input.Length; i++)
            {
                char c = (char)input[i];
  
                if (inTextObject)
                {
                    // Position the text
                    if (bracketDepth == 0)
                    {
                        if (CheckToken(new string[] { "TD", "Td" }, previousCharacters))
                        {
                            resultString += "\n\r";
                        }
                        else
                        {
                            if (CheckToken(new string[] { "'", "T*", "\"" }, previousCharacters))        {
                                resultString += "\n";
                            }
                            else
                            {
                                if (CheckToken(new string[] { "Tj" }, previousCharacters))
                                {
                                    resultString += " ";
                                }
                            }
                        }
                    }
  
                    // End of a text object, also go to a new line.
                    if (bracketDepth == 0 && CheckToken(new string[] { "ET" }, previousCharacters))
                    {
                        inTextObject = false;
                        resultString += " ";
                    }
                    else
                    {
                        // Start outputting text
                        if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
                        {
                            bracketDepth = 1;
                        }
                        else
                        {
                            // Stop outputting text
                            if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
                            {
                                bracketDepth = 0;
                            }
                            else
                            {
                                // Just a normal text character:
                                if (bracketDepth == 1)
                                {
                                    // Only print out next character no matter what.
                                    // Do not interpret.
                                    if (c == '\\' && !nextLiteral)
                                    {
                                        nextLiteral = true;
                                    }
                                    else
                                    {
                                        if (((c >= ' ') && (c <= '~')) || ((c >= 128) && (c < 255)))
                                        {
                                            resultString += c.ToString();
                                        }
  
                                        nextLiteral = false;
                                    }
                                }
                            }
                        }
                    }
                }
  
                // Store the recent characters for
                // when we have to go back for a checking
                for (int j = 0; j < _numberOfCharsToKeep - 1; j++)
                {
                    previousCharacters[j] = previousCharacters[j + 1];
                }
                
                previousCharacters[_numberOfCharsToKeep - 1] = c;
  
                // Start of a text object
                if (!inTextObject && CheckToken(new string[] { "BT" }, previousCharacters))
                {
                    inTextObject = true;
                }
            }
            return resultString;
        }
        catch
        {
            return string.Empty;
        }
    }
  
    private bool CheckToken(string[] tokens, char[] recent)
    {
       foreach (string token in tokens)
       {
          if ((recent[_numberOfCharsToKeep - 3] == token[0]) &&
           (recent[_numberOfCharsToKeep - 2] == token[1]) &&
           ((recent[_numberOfCharsToKeep - 1] == ' ') ||
           (recent[_numberOfCharsToKeep - 1] == 0x0d) ||
           (recent[_numberOfCharsToKeep - 1] == 0x0a)) &&
           ((recent[_numberOfCharsToKeep - 4] == ' ') ||
           (recent[_numberOfCharsToKeep - 4] == 0x0d) ||
           (recent[_numberOfCharsToKeep - 4] == 0x0a)))
           {
                    return true;
           }
        }
        return false;
     }
