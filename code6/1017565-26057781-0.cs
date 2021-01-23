    public abstract class Element
    {
        public virtual void MaybeSpecificCall()
        {
            // nothing in most cases
        }
    }
    
    public abstract class Program : Element
    {
        public override void MaybeSpecificCall()
        {
            base.MaybeSpecificCall();
            // but in this specific case, do something
            SpecificProgramCall(); 
        }
    
        public void SpecificProgramCall() { /* ... */ }
    }
