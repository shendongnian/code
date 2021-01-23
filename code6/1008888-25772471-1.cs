    public static class WordDocument
    {
        public const String TemplateName = @"Sample.dotx";
        public const String CurrentDateBookmark = "CurrentDate";
        public const String SignatureBookmark = "Signature";
        
        public static void Create(string file, DateTime now, String author)
        {
             // Run Word and make it visible for demo purposes
             dynamic wordApp = new Application { Visible = true };
                    
            // Create a new document
            var doc = wordApp.Documents.Add(TemplateName);
            templatedDocument.Activate();
                
            // Fill the bookmarks in the document
            doc.Bookmarks[CurrentDateBookmark].Range.Select();
            wordApp.Selection.TypeText(current.ToString());
            doc.Bookmarks[SignatureBookmark].Range.Select();
            wordApp.Selection.TypeText(author);
          
