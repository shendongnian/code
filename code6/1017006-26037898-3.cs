    public class Data
    {
        public string Token1 { get; set; } // use a meaningful name
        public string Token2 { get; set; } // use a meaningful name
        public DateTime Date { get; set; } // use a meaningful name
        public override string ToString()
        {
            return string.Format("Token1:[{0}] Date:[{1}] Token2:[{2}]", 
                Token1,
                Date.ToString("MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture), 
                Token2);
        }
    }
