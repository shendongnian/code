     public void HookUpTheEventWithTheHandler()
        {
            MyEvent += MyEventHandler;
        }
        public void MyEventHandler(int x, bool condition)
        {
            // Do some processing here....
        }
