            static public double SQRTByGuess(double num)
            {
                // Assume that the number is less than 1,000,000. so that the maximum of SQRT would be 1000.
                // Lets assume the result is 1000. If you want you can increase this limit
                double min = 0, max = 1000;
                double answer = 0;
                double test = 0;
                if (num < 0)
                {
                    Console.WriteLine("Negative numbers are not allowed");
                    return -1;
                }
                else if (num == 0)
                    return 0;
     
                while (true)
                {
                    test = (min + max) / 2;
                    answer = test * test;
                    if (num > answer)
                    {
                        // min needs be moved
                        min = test;
                    }
                    else if (num < answer)
                    {
                        // max needs be moved
                        max = test;
                    }
                    if (num == answer)
                        break;
                    if (num > (answer - 0.0001) &&
                        num < (answer + 0.0001))
                        break;
                }
                return test;
            }
