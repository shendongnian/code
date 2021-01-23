    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] stringArray = { "333", "Hello World", "A", "World gone mad and society has, too" };
                List<string> newStrings = new List<string> ();
    
                foreach (string currentString in stringArray)
                {
                    bool finished = false;
                    int start = 0;
                    int end = 0;
                    while (!finished)
                    {
    
                        if (currentString.Length == end)
                        {
                            finished = true;
                            newStrings.Add(currentString.Substring(start, end - start));
                        }
                        else if (Measure(currentString.Substring(start, end - start)) == 0)
                        {
                            newStrings.Add(currentString.Substring(start, end - start));
    
                            start = end;
                        }
                        else if (Measure(currentString.Substring(start, end-start)) < 0)
                        {
                            end++;
                        }
                        else //adding one more made it too long
                        {
                            end--;
                            newStrings.Add(currentString.Substring(start, end - start));
                            start = end;
                        }
                    }
                }
    
                foreach (string s in newStrings)
                {
                    Console.WriteLine(s);
                }
    
                Console.ReadLine();
    
            }
    
    
    
            private static int Measure(string s)
            {
                //you would check using something like 
                //int length = ((int)consolas.MeasureString(stringArray[i]).Length()); 
                //int requiredValue = 30;
                //but I have substituted just plain string.Length to show the logic
    
                int length = s.Length;
                int requiredValue = 3;
    
                if (length == requiredValue) return 0;
                if (length < requiredValue) return -1;
    
                return 1;
            }
        }
    }
