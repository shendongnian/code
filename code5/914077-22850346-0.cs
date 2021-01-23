    public class LineItem
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateTaken { get; set; }
        public string Comments { get; set; }
        public LineItem(string textRow)
        {
            if (!string.IsNullOrEmpty(textRow) && textRow.Contains(','))
            {
                string[] parts = textRow.Split(',');
                if (parts.Length == 5)
                {
                    // correct length
                    FileName = parts[0];
                    Description = parts[1];
                    Category = parts[2];
                    Comments = parts[4];
                    // this needs some work
                    DateTime dateTaken = new DateTime();
                    if (DateTime.TryParse(parts[3], out dateTaken))
                    {
                        DateTaken = dateTaken;
                    }
                }
            }
        }
    }
