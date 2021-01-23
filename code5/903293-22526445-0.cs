    public class Foo
    {
        public void DoSomething()
        {
            await Something(); //invalid
            Something(); //valid
        }
    
        public async void Something() 
        {
            await SomethingElse(); //valid
            SomethingElse(); // also valid, but synchronous
        }
    
        public async void SomethingElse()
        {
        }
    }
