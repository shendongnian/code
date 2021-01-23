    static Object[] prac = new Object[10];
    public static void Main(string[] args)
    {
        SpecificType myObject = prac[0] as SpecificType; // returns null if not successful
        if (myObject != null)
            myObject.age = 21;
    }
