    using System;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Globalization;
    
    namespace ClassLibrary1
    {
        [Guid("a81acfd7-ca29-4b71-b45d-d9ffd8930036")]
        public interface ITest
        {
            string HelloWorld(string name);
        }
    
        [Guid("bb212288-fa1a-432a-9456-e1c3bb78923f"), ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public class Test : ITest
        {
            public string HelloWorld(string name)
            {
                return "Hello World! I'm " + name;
            }
        }
    
    
    }
