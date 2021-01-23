    using System;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string testString = "S KESRNAN S FOREST BV S";
                // deleting S in middle of string
                for (int i = 1; i < testString.Length-1; i++)
                {
                    if (testString[i]=='S'&&testString[i-1]==' '&&testString[i+1]==' ')
                        testString=testString.Remove(i,2);
                }
                // deleting S in the begining of string
                if (testString.StartsWith("S "))
                    testString = testString.Remove(0, 2);
                // deleting S at the end of string
                if (testString.EndsWith(" S"))
                    testString = testString.Remove(testString.Length-2, 2);
                Console.WriteLine(testString);
            }
        }
    }
