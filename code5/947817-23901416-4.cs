    //have your class implements the interface
    public class SomeClass1 : IInterface
    {
        public string property1;
        public string property2;
        public string property3;    
    }
    
    
    public static void main(string[] args)
    {
        SomeClass1 someObject1 = new SomeClass 
        {
            property1 = "prop1"
            property1 = "prop2"
            property1 = "prop3"
        };
            //Create a list of IInterface
           List<IInterface> listofinterface  = new List<IInterface>();
  
           //Instanciate someclass2 passing the interface list created in earlier step
           SomeClass2 cls2 = new SomeClass2(listofinterface);
    
           //call your GetEnumObjects method passing the someclass1 object
           cls2.GetEnumObjects(someObject1);  
    }
