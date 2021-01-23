    public class Test
    {
        public int Prop {get;set;}
        
        public Test DoStuf()
        {
            Prop=1;
            return this;
        }
    
        public Test DoOtherStuff()
        {
           return new Test();
        }
    }
