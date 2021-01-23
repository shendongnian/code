            Console.Write("Enter a positive number for length of the first array: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter a positive number for length of the second array: ");
            int m = int.Parse(Console.ReadLine());
 
            // Declare and create the arrays
            char[] firstArray = new char[n];
            char[] secondArray = new char[m];
            Console.WriteLine("Enter values of the arrays: ");
            for (int i = 0; i <  firstArray.Length; i++)
            {
                firstArray[i] = char.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                secondArray[i] = char.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            // Print them on the console
            for (int i = 0; i < n; i++)
            {
                Console.Write(" " + firstArray[i]);
            }            
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                Console.Write(" " + secondArray[i]);
            }            
            Console.WriteLine();
           
            int minLength = Math.Min(firstArray.Length, secondArray.Length);
            bool equalValues = true;
            // Search which of the arrays is lexicographically earlier
                for (int i = 0; i < minLength; i++)
                {
                    if (firstArray[i] == secondArray[i])
                    {
                        continue;
                    }
                    else if (firstArray[i] < secondArray[i])
                    {
                        Console.WriteLine("The first array is earlier.");
                        break;
                    }
                    else if (firstArray[i] > secondArray[i])
                    {
                        Console.WriteLine("The second array is earlier.");
                        break;
                    }
                }
                for (int i = 0; i < minLength; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        equalValues = false;
                    }
                }
                // This is to indicate the values of the two arrays till the element of index minLength-1 are equal
                for (int i = 0; i < minLength; i++)
                {
                    if (equalValues && n < m)
                    {
                        Console.WriteLine("The first array is earlier.");
                        break;
                    }   
                    else if (equalValues && n > m)
                    {
                        Console.WriteLine("The second array is earlier.");
                        break;
                    }
                    else if (equalValues && n == m)
                    {
                        Console.WriteLine("The two arrays aree equal.");
                        break;
                    }          
                }                          
