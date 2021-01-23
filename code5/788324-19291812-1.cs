        static class Pie
        {
              public static void Pin ()
              {
                int r;//defining the value that is going to be entered as an interger 
                double result;//declaring the result string as a double
                r = (int)Convert.ToDouble(Console.ReadLine());
                result=(3.14*r*r);//the calculation to work out pie
                Console.WriteLine("The Radius of the circle is " + (result));//the writeline statement    
             }
        }
