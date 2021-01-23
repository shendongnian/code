    using System;
    
    internal class CompareTwoCharArraysLexicographically
    {
        private static void Main()
        {
            char[] firstArray = { 'a', 'b', 'c', 'z' };
            int firstArrayLength = firstArray.Length;
            char[] secondArray = { 'a', 'b', 'c', 'd' };
            int secondArrayLength = secondArray.Length;
            int length = Math.Min(firstArray.Length, secondArray.Length);
            bool same = false;
    
            if (firstArray.Length > secondArray.Length)
            {
                Console.WriteLine("Second array is earlier.");
            }
    
            else if (firstArray.Length == secondArray.Length)
            {
                for (int i = 0; i < length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        same = false;
    
    
                        if (firstArray[i] > secondArray[i])
                        {
                            Console.Clear();
                            Console.WriteLine("2 array is earlier.");
                            break;
                        }
                        if (secondArray[i] > firstArray[i])
                        {
                            Console.Clear();
                            Console.WriteLine("1 array is earlier.");
                            break;
                        }
    
                    }
    
    
    
                    else same = true;
    
    
                    if (same == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Two arrays are equal."); 
                        
                    }
    
                    else
                    {
                        Console.WriteLine("First array is earlier.");
                    }
                }
            }
        }
    }
