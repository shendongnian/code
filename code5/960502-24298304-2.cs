    class Program
    {
        static void Main(string[] args)
        {
            NewState MyVariable = new NewState();
            MyVariable.State();
        }
    }
    class NewState
    {
        public void State()
        {
            Console.WriteLine("Hello world");
        }
    }
