    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestTryParseDelegate
    {
        class Program
        {
            private delegate bool TryParseDelegate<T>(string candidate, out T result)
                where T : struct;
    
            private static Tuple<bool, T> Validate<T>(string candidate, TryParseDelegate<T> tryParseDel)
                where T : struct
            {
                T result;
                return Tuple.Create(tryParseDel(candidate, out result), result);
            }
    
            public static Tuple<bool, int> ValidateInt(string TheCandidateInt)
            {
                return Validate<int>(TheCandidateInt, int.TryParse);
            }
    
            public static void Main()
            {
                var result = ValidateInt("123");
                Console.WriteLine(result);
            }
        }
    }
