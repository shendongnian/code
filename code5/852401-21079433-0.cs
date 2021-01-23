    using System;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
     
    public class dynamic_demo
    {
        static void Main()
        {
            var ipy = Python.CreateRuntime();
            dynamic test = ipy.UseFile("Test.py");
            test.Simple();
        }
    }
