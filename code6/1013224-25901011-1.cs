    class App
    {
        public void CallDoSomethingWithTheHeight()
        {
            NewClass.DoSomethingWithTheHeight(this);
        }
    }
    
    static class NewClass
    {
        public static void DoSomethingWithTheHeight(App application)
        {
            int heightd = (int)application.Height;
            //more code
        }
    }
