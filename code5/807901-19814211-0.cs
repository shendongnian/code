    public class TestObject
    {
        public int ObjID { get; set; }
        public string ObjName { get; set; }
    
        public TestObject() 
        { 
        }
    
        public TestObject(int id, string name) 
        {
            ObjID = id;
            ObjName = name;
        }
    }
