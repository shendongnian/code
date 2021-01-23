    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ClassLibrary1.Car")]
    public class Car
    {
        public Car()
        {
            Name = "";
            Parts = new string[];
        }
    
        public string Name { get; set; }
    
        public string[] Parts { get; set; }
    }
