        public class Loan
        {
            [XmlIgnore]
            private DateTime _dateOut;
    
            public string OutDate
            {
                get { return _dateOut.ToString("dd-MM-yyyy"); }
                set { _dateOut = DateTime.Parse(value); }
            }
        }
