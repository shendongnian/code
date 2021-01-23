    using test = System.Threading.Thread;
    namespace Y
    {
        public class X
        {
            public void Method()
            {
               test.Sleep(1000); //Same as System.Threading.Thread.Sleep(1000);
            }
        }
    }
