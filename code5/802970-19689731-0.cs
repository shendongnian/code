    public ref class MyClass
    {
    public:
        static void MyMethod(IMessage^ message)
        {
            message->DoSomething();
        }
    };
