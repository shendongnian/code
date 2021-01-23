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
                if (tryParseDel(candidate, out result))
                {
                    return new Tuple<bool, T>(true, result);
                }
                else
                {
                    return new Tuple<bool, T>(false, default(T));
                }
            }
    
            public static Tuple<bool, int> ValidateInt(string TheCandidateInt)
            {
                return Validate<int>(TheCandidateInt, delegate(string x, out int y) { return int.TryParse(x, out y); });
            }
    
            public static void Main()
            {
                var result = ValidateInt("123");
                Console.WriteLine(result);
            }
        }
    }
