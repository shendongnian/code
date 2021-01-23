    using System;
    class StackOverFlow
    {
    static void Main()
    {
        Console.Write(StackOverFlow.TimeStamp());
    }
    public static decimal TimeStamp()
    {
        decimal returner = DateTime.Now.Millisecond * 1000;
       
        return returner;
    }
    }
