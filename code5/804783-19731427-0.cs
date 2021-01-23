    public static SingleTonSample InstanceCreation()
    {
        private static object lockingObject = new object();
        if(singleTonObject == null)
        {
             lock (lockingObject)
             {
                 singleTonObject = new SingleTonSample();
                 
             }
        }
        return singleTonObject;
    }
