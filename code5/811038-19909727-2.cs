    public static class MyExt
    {
        public static void MyExtension(this object obj)
        {
            //Do something
        }
    }    
    public static void Main()
    {
        object obj = new object();
        obj.MyExtension();
        //Above line gets compiled into MyExt.MyExtension(obj);
    }
