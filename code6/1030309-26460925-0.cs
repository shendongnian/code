    public class Product
    {
        private readonly string csvData;
        public Product(string _csvData)
        {
            csvData = _csvData;
            
            ValidateCSV()
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public void ValidateCSV()
        {
            string[] splitCsv = csvData.Split(',');
            if (splitCsv.Length != 3)
                throw new ArgumentException("CVS should contain 3 values, only contained " + splitCsv.Length);
            if (!splitCsv[0].IsNumeric())
                throw new ArgumentException("The first item should be a number");
            //Possibly populate the class as well if it checks out
            ProductId = int.Parse(splitCsv[0]); // could be combined with the check with something like TryParse
            Name = splitCsv[1];
            Quantity = int.Parse(splitCsv[2]); // We didn't validate this one
        }
    }
