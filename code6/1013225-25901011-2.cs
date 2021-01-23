    class App
    {
        public void CallDoSomethingWithTheHeight()
        {
            NewClass instanceOfNewClass = new NewClass();
            instanceOfNewClass.DoSomethingWithTheHeight(this);
        }
    }
    
    class NewClass
    {
        public void DoSomethingWithTheHeight(App application)
        {
            int heightd = (int)application.Height;
            //more code
        }
    }
