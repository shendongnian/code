        public class Document
        {
            #region Properties
            public int ID { get; set; }
            public string Name { get; set; }
            public string FileName { get; set; }
            #endregion Properties
        }
        public class DocumentList : List<Document>
        {
        }
