    using System;
    class TestGetElementType 
    {
        public static void Main() 
        {
            int[] array = {1,2,3};
            Type t = array.GetType();
            Type t2 = t.GetElementType();
            Console.WriteLine("The element type of {0} is {1}.",array, t2.ToString());
            TestGetElementType newMe = new TestGetElementType();
            t = newMe.GetType();
            t2 = t.GetElementType();
            Console.WriteLine("The element type of {0} is {1}.", newMe, t2==null? "null" : t2.ToString());
        }
    }
