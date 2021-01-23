    public class Test
    {
        static System.Collections.IEnumerator enumerator;
        static void Main()
        {
            // Display powers of 2 up to the exponent of 8: 
            enumerator = Power(2, 8);
            bool done = false;
            while (!done)
                done = !timerEvent();
        }
        
        static bool timerEvent()
        {
        	if (!enumerator.MoveNext())
        	    return false;
        	else
                Console.Write("{0} ", enumerator.Current);
            return true;
        }
    
        // This will be your function
        static System.Collections.IEnumerator Power(int number, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
        // Output: 2 4 8 16 32 64 128 256
    }
