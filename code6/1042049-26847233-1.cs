    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class MyService : IMyService{
    {
        private int _counter;
        public int Test(){ return _counter++; }
    }
