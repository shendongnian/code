    public class Baseclass
    {
        public Baseclass(string anyparam)
        {
    
        }
        public Baseclass(Func<string> f):this(f())
        {
    
        }
    }
    
    public class Subclass : Baseclass
    {
        public Subclass()
            : base(()=> 
                    {
                        string returnstring="foo";
    
                        // Do Something
    
                        return returnstring; 
                    })
        {
    
        }
    }
