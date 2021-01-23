    class MyInfo
    {
        public int MyProperty{ get; private set; }
    
        public MyInfo WithMyProperty(int value)
        {
           return new MyInfo(){ MyProperty = value };
        }
    }
    MyInfo obj = ds.GetInfo();
    MyInfo modified = obj.WithMyProperty(1234);
