    public abstract class PayrollBase<T> where T : Person
    {
        public void DoSomething(IEnumerable<T> peopleIn)
        {
            // Do this with peopleIn
            // Do that with peopleIn
            this.InternalLogic(peopleIn);
        }
    
        protected virtual InternalLogic(IEnumerable<T> peopleIn)
        {
           // do something super special
        }
    }
