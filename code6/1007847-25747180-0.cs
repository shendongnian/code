    #if !DEBUG
    #define NOTDEBUG
    #endif
    
    namespace Test123
    {
        using System;
        using System.Diagnostics;
    
        class Program
        {
            static void Main(string[] args)
            {
                var someCondition = false;
    
                Trace(someCondition);
            }
    
            [Conditional("NOTDEBUG")]
            static void Trace(bool condition)
            {
                if (!condition)
                {
                    throw new Exception();
                }
            }
        }
    }
