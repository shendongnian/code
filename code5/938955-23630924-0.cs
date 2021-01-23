    private static object locker = new object();
    public static int add(int a, int b)
    {
         lock(locker) 
         {
             //do stuff
         }
    }
