        public void BeginTesting() // start testing
        {
            //Step 1 : Print number 1 to 100
            for (int i = 1; i <= 100; i++)
            {
                var results = string.Empty;
                // Step 2 :- Divisable by 9 print Fizz
                if (i % 9 == 0)
                {
                    results = "Fizz";
                    TotalFizz++;
                }
                    
                // Step 3 :- Divisable by 13 print Buzz
                if (i % 13 == 0)
                {
                    results = "Buzz";
                    TotalBuzz++;
                }
                    
                // Step 4 :- Divisable by 9 and 13 print FizzBuzz
                if (i % 9 == 0 && i % 13 == 0)
                {
                    results = "FizzBuzz";
                    TotalFizzBuzz++;
                }
                if (string.IsNullOrEmpty(results))
                {
                    // Step 5 :- Print the number as it is if not divisable by 9 or 13
                    Console.WriteLine(i.ToString());
                }
                Console.WriteLine(results);
            }
        }
