    static class Program
    {
        static event EventHandler MyEvent;
        static void Main()
        {
            // registering event
            MyEvent += Program_MyEvent;
            MyEvent += Program_MyEvent;
            MyEvent += Program_MyEvent;
            MyEvent += Program_MyEvent;
            MyEvent += Program_MyEvent;
            // invoke event
            MyEvent(null, EventArgs.Empty);
            Console.ReadKey();
        }
        static void Program_MyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("MyEvent fired");
        }
    }
