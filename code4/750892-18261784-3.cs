    class Program
    {    
        static void Main(string[] args)
        {
            SampleClass s = new SampleClass(); // create instance of class with event
            s.SampleEvent += SampleEventHandler; // subscribe to event
            s.Invoke(); // invoke some logic which raises event
        }
    
        private static void SampleEventHandler()
        {
            Console.WriteLine("Invoked"); // handle event
        }
    }
