        namespace Foo
    {
        class Bar
        {
            static void Main(string[] args)
            {
                Console.WriteLine(YourFunction("ABCABCABCABCABCABCABC", 3, 0,1));
                Console.ReadKey();
            }
    
    
            static string YourFunction(string SubString, int PatternLength, int Offset, int SubstringLength)
            {
                string result;
                if (SubString.Length <= PatternLength)
                {
                    result = SubString.Substring(Offset, SubstringLength);
                }
                else
                {
                    result = YourFunction(SubString.Substring(PatternLength, (SubString.Length - PatternLength)), PatternLength, Offset, SubstringLength) + SubString.Substring(Offset, SubstringLength);
                }
                return result;
            }
        }
    }
