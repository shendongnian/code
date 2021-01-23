    public static SingletonSample InstanceCreation()
    {
        private static object lockingObject = new object();
        if(singletonObject == null)
        {
             lock (lockingObject)
             {
                 singletonObject = new SingletonSample();
                 
             }
        }
        return singletonObject;
    }
