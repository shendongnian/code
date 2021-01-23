    public abstract class YourAbstractClass 
    {
        public abstract int ID { get; set; }
    }
    
    public class ConcreteClass1 : YourAbstractClass
    {
        public override int ID
        { 
            get { return SomeID } 
            set { SomeID = value } 
        }
    }
