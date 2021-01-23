    public class ViewModelBase 
    {
        private string _aProperty = "A";
        public virtual string AProperty 
        {
            get { return _aProperty; }
        }
        public void DoSomething() 
        {
            Console.WriteLine(AProperty);
        }
    }
    public class DerivedViewModel : ViewModelBase 
    {
        private string _bProperty = "B";
        public override string AProperty 
        {
            get { return _bProperty; }
        } 
    }
    DerivedViewModel dr = new DerivedViewModel();
    dr.DoSomething();//Prints B
