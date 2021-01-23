    using System;
    
    namespace replace
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var damaged = ">?xml version='1.0' encoding='windows-1252'?<"
                                + ">level1<"
                                    + ">level2<"
                                        + ">level3<"
                                            + ">Object Value='TEST'<"
                                         + ">/level3<"
                                    + ">/level2<"
                                 + ">/level1<"
                             + ">/XML<";
                Console.WriteLine("Default:");
                Console.WriteLine(damaged);
    
                damaged = damaged.Replace("<>", "><");
                Console.WriteLine("Step1:");
                Console.WriteLine(damaged);
    
                damaged = damaged.ReplaceAt(0, '<');
                var Fixed = damaged.ReplaceAt(damaged.Length - 1, '>');
                Console.WriteLine("Step2:");
                Console.WriteLine(Fixed);
    
                Console.Read();
            }
        }
    
        public static class Extension
        {
            public static string ReplaceAt(this string input, int index, char newChar)
            {
                if (input == null)
                {
                    throw new ArgumentNullException("input");
                }
                char[] chars = input.ToCharArray();
                chars[index] = newChar;
                return new string(chars);
            }
        }
    }
