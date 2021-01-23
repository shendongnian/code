    public interface ITemplate
    {
        bool DoSomething(string a);
    }
    
    public class Worker
    {
        public void DoSomeWork(ITemplate subcontractor)
        {
            //Do some work...
            if(subcontractor.DoSomething("hello"))
            {
                //Do some more work
            }
        }
    }
    
    public BaseClass : ITemplate
    {
        public void myFunction1()
        {
            Worker worker = new Worker();
            worker.DoSomeWork(this);   
        }
    
        public bool DoSomething(string a)
        {
            //Some code here
        }
    }
    
    public DerivedClass : BaseClass
    {
        public void myFunction2()
        {
            Worker worker = new Worker();
            worker.DoSomeWork(this);   
        }
    }
