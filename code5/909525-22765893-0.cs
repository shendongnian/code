    static void Main(string[] args)
    {
    
        // Load in the document
        Document doc = new Document("C:\\data\\Testing.doc");
    
        //Regular expression for findinf Full Name string   
        Regex regex = new Regex("Full Name", RegexOptions.IgnoreCase);
    
        //To find the text and insert the paragraph
        doc.Range.Replace(regex, new ReplaceEvaluatorFindandHighlight(), true);
    
        doc.Save("C:\\data\\document_new.doc");    
    
    }
    
    //Class to find the text as per key string
    private class ReplaceEvaluatorFindandHighlight : IReplacingCallback
    {
        /// <summary>
        /// This method is called by the Aspose.Words find and replace engine for each match.
        /// This method highlights the match string, even if it spans multiple runs.
        /// </summary>
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // This is a Run node that contains either the beginning or the complete match.
            Node currentNode = e.MatchNode;
            
            //Use Document Builder to Navigate to the paragraph
            DocumentBuilder builder = new DocumentBuilder((Document)e.MatchNode.Document);
    
            builder.MoveTo(currentNode.ParentNode);
            
            //Insert a Paragraph break
            builder.InsertParagraph();
            
            //Insert the Paragraph for the Text we have search
            builder.Writeln(currentNode.ParentNode.ToString(SaveFormat.Text)); // Inserts a string and a paragraph break into the document. 
       
            // Signal to the replace engine to do nothing because we have already done all what we wanted.
            return ReplaceAction.Skip;
        }   
    }
