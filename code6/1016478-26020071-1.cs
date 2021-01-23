    public class B : IA
    {
        public void DoSomething(long x)
        {
            // B's custom implementation
        }
        public void IWantSomethingElse(string s)
        { 
            // this is only class specific and cannot be called from the interface
        }
    }
    
    /* Some method somewhere */
    public void DoThisThing()
    {
        IA a = new B();
    
        a.DoSomething(2);
        // here there is no way to call IWantSomethingElse because the its not on the interface
    }
