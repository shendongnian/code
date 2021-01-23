    Something(new int[10]);
     
    static void Something(ICollection collection)
    {
        //The dynamic keyword tells the compilier to look at the underlying information
        //at runtime to determine the variable's type.  In this case, the underlying 
        //information suggests that dynamic should be an array because the variable you
        //passed in is an array.  Then it'll try to call System.Array.Count.
        dynamic dynamic = collection;
        Console.WriteLine("Count is:{0}", dynamic.Count);
    
        //If you check the type of variable, you'll see that it is an ICollection because
        //that's what type this function expected.  Then this code will try to call 
        //System.ICollection.Count
        var variable = collection;
        Console.WriteLine("Count is:{0}", dynamic.Count);
    }
