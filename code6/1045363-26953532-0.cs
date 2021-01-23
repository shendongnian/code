       class NumberManipulator
        {
            public int factorial(int num)
            {
             int b=1;
              do
               {
                fact=fact*b;//fact has the value 1  as constant and fact into b will be save in fact to multiply again. 
                 Console.WriteLine(fact);
                 b++;
                 } while(num>=b); // a is greater and equals tob.
              }
         }
