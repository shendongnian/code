    public class Params
    {
        public int value3;
        public int value4;
    }
    public class Message
    {
        public int value1;
        public int value2;
        public Params[] parameters;
    }
    Message[] messageList =
    {
        new Message { value1 = 1, value2 = 2, parameters = new[] { new Params { value3 = 1, value4 = 1 } } },
        new Message { value1 = 3, value2 = 4, parameters = new[] { new Params { value3 = 2, value4 = 2 } } }
    };
