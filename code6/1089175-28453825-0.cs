    public MyClass : IValuesSource
    {
        public string someString {get;set;}
        public double someDouble {get;set;}
        public bool someBool {get;set;}
        public List<string> valList {get;set;}
        public List<string> valList2 {get;set;}
    
        public List<string> Values
        {
            get
            {
                var values = new List<string>();
                values.Add(someString);
                values.Add(someDouble.ToString());
                values.Add(someBool.ToString());
                values.AddRange(valList);
                values.AddRange(valList2);
                return values;
            }
        }
    }
