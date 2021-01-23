    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ClassLibrary1.Car")]
    public class Car
    {
        private List<string> _Parts;
        public Car()
        {
            Name = "";
            _Parts = new List<string>();
        }
    
        public string Name { get; set; }
    
        public string[] Parts 
        { 
            get
            {
                return _Parts.ToArray();
            } 
            set
            {
                _Parts = new List<string>(value);
            } 
        }
    }
