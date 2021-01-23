    //**[MakeVisibleListInVB6]**
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("ClassLibrary1.Car")]
    public class Car
    {
        public Car()
        {
            Name = "";
            Parts = new Parts();
        }
    
        public string Name { get; set; }
    
        public List<string> Parts { get; set; }
    }
