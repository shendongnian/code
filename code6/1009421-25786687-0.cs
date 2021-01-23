    public class Boo
    {
        private readonly Test _test = new Test();
    
        public void foo()
        {
            _test.start();
    
            _test.NotifyMe += (sender, e) =>
            {   
                Console.WriteLine("Manager has changed the state");
            }   
        }
    }
