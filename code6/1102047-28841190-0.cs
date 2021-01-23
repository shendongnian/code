        class Program
    {
        static void Main(string[] args)
        {
        }
        void Test()
        {
            MyClass mainObj = new MyClass();
            MyClass otherObj = new MyClass();
            mainObj.StartListeningToObject(otherObj);
            //...
            mainObj.StopListeningToObject(otherObj);
        }
    }
    class MyClass
    {
        public event EventHandler<EventArgs> MessageReceived;
        private void MessageFromOtherObject_Received(object sender, EventArgs arg)
        {
            //do some work
        }
        public void StartListeningToObject(MyClass obj)
        {
            obj.MessageReceived += MessageFromOtherObject_Received;
        }
        public void StopListeningToObject(MyClass obj)
        {
            obj.MessageReceived -= MessageFromOtherObject_Received;
        }
    }
