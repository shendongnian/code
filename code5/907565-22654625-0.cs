        private interface IMessage { void Test(); }
        private class Message { }
        private class DerivedMessage<T> : Message, IMessage where T : BaseClass { public void Test() { Console.WriteLine("Test"); } };
        private class BaseClass { }
        private class DerivedClass : BaseClass{};
        static void Main(string[] args)
        {
            Message msg = new DerivedMessage<DerivedClass>();
            IMessage mess = msg as IMessage;
            mess.Test();
        }
