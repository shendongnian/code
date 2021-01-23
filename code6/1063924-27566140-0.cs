    using System;
    
    delegate TResult ParamsFunc<T, TResult>(params T[] arg);
    delegate TResult ParamsFunc<T1, T2, TResult>(T1 arg1, params T2[] arg2);
    delegate TResult ParamsFunc<T1, T2, T3, TResult>(T1 arg1, T2 arg2, params T3[] arg3);
    // etc        
    
    class Program
    {
        static void Main(string[] args)
        {
            ParamsFunc<string, string, string> func =
                (format, values) => string.Format(format, string.Join("-", values));
            
            string result = func("Look here: {0}", "a", "b", "c");
            Console.WriteLine(result);
        }
    }
