    public class AtsPlatform
    {
        public string Name { get; set; }
        public string RequestNumber { get; set; }
        public Int32? NumberOfFail { get; set; }
        public Int32? NumberOfTestCase { get; set; }
        public Int32? NumberOfFailWithCR { get; set; }
    
        public void Parse(string name, string requestNumber, string numberOfFail, string numberOfTestCase, string numberOfFailWithCR)
        {
            Int32 temp;
    
            this.Name = name;
            this.RequestNumber = requestNumber;
            this.NumberOfFail = (Int32.TryParse(numberOfFail, out temp)) ? Int32.Parse(numberOfFail) : 0;
            this.NumberOfTestCase = (Int32.TryParse(numberOfTestCase, out temp)) ? Int32.Parse(numberOfTestCase) : 0;
            this.NumberOfFailWithCR = (Int32.TryParse(numberOfFailWithCR, out temp)) ? Int32.Parse(numberOfFailWithCR) : 0;
        }
    }
