    [DataContract(Name="Reply")]
    public class Base
    {
        [DataMember]
        public virtual int IntValue { get; set; }
    
    }
    
    [DataContract(Name = "Reply")]
    public class Derived : Base
    {
    
        public String StringProperty { get; set; }
    }
    Derived blah = new Derived { IntValue = 3, StringProperty = "blah" };
    public Base SomeOperation()
    {
         return blah;
    }
