    using System;
    
    namespace AAA
    {
        class MyException : Exception
        {    
    
        }
        class MainClass
        {
            public static void Main (string[] args)
            {
                try
                {
                    throw new MyException();
                }
                catch (MyException m)
                {  
                    //TODO: something
                }
                catch (Exception e)
                {
                    //TODO: something
                }
            }
        }
    }
