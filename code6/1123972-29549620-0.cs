        public static List<Values> GetValues(string path)
        {
            List<Values> valuesCollection = new List<Values>();;
            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    valuesCollection.Add(new Values(Convert.ToDateTime(parts[0]), Convert.ToInt32(parts[1]), parts[2]); 
                }
            }
            return valuesCollection;
        }
        class Values
        {
            public DateTime Date { get; set; }
            public int IntValue { get; set; }
            public string StringValue { get; set; }
            public Values()
            {
            }
            public Values(DateTime date, int intValue, string stringValue)
            {
                this.Date = date;
                this.IntValue = intValue;
                this.StringValue = stringValue;
            }
        }
