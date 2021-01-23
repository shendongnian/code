     abstract class A
        {
            public Master Parent;
                public virtual void DoSomething()
                {
                    //This block is missing in your code
                }
        }
    
 
     static void Main(string[] args)
        {
            var m = new Master();
            m.a = new A1 {Parent = m};
            m.DoSomething();
        }
