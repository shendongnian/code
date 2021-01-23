    interface ISomething1
    {
        void DoSomething()
    }
    
    interface ISomething2
    {
        void DoSomething()
    }
    class MyClass : ISomething1, ISomething2
    {
        void ISomething1.DoSomething()
        {
            //Do something
        }
    
        void ISomething2.DoSomething()
        {
            //Do something else
        }
    }
