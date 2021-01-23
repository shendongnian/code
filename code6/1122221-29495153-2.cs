        class Program
       {
        static void Main()
        {
            try
            {
                int[] array = new int[100];
                array[0] = 1;
                array[10] = 2;
                array[200] = 3; // this line will through *IndexOutOfRangeException* Exception
                object o = null;
                o.ToString(); // this line will through *NullReferenceException* Exception
            }
            /* the below catch block(IndexOutOfRangeException class) will only catch *IndexOutOfRangeException* and not *NullReferenceException*
              hence you can say it as Specific Exception as it is catching only a particular exception.
            */
            catch (IndexOutOfRangeException e) 
            {
                Console.WriteLine("Incorrect Index"); // Or any of you Custom error message etc.
            }
            /* the below catch block(Exception class) will catch all the type of exception and hence you can call it as Generic Exception.
            */
            catch (Exception e)
            {
                Console.WriteLine("Opps Something Went Wrong..."); // Or any of you Custom error message etc.
            }
        }
    }
