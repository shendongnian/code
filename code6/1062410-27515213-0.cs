    public static object GetFirstObjectInstance
    {
        get
        {
            if(o1==null)
            {
                o1=new object();
            }
            return o1;
        }
    }
