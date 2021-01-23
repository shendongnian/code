    class Program
    {
        static void Main(string[] args)
        {
            Action<String> StringAction = new Action<string>((a) => WriteString(a));
            Action<Int32> Int32Action = new Action<Int32>((a) => WriteString(a.ToString()));
            Messenger.Subscribe<String>("Sub1", StringAction);
            Messenger.Send<String>("Sub1", "I am a string");
            Messenger.Subscribe<Int32>("Sub2", Int32Action);
            Messenger.Send<Int32>("Sub2", 72);
            Console.ReadLine();
        }
        private static String WriteString(String message)
        {
            Console.WriteLine(message);
            return message;
        }
    }
