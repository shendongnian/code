    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            Load(new Respository<int>());
            Load(new Respository<string>());
            Console.ReadLine();
        }
        class Respository<T> { }
        static List<T> Load<T>(Respository<T> repository)
        {
            Dump(); // <-- Just dump this
            return default(List<T>);
        }
        static void Dump()
        {
            // Get the method that invoked the method being dumped
            var callerFrame = new StackFrame(2);
            var callerMethod = callerFrame.GetMethod();
            // Get the method that is being dumped
            var calleeFrame = new StackFrame(1);
            var calleeMethod = calleeFrame.GetMethod();
            // Should return one value
            var callees = from il in new ILReader(callerMethod).OfType<InlineMethodInstruction>()
                          let callee = callerMethod.Module.ResolveMember(il.Token)
                          where callee.Name == calleeMethod.Name && il.Offset == callerFrame.GetILOffset()
                          select callee;
            Console.WriteLine(callees.First());
        }
    }
