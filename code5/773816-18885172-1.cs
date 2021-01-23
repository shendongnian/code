    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ListObjects
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<TestObject> ObjectList = new List<TestObject>();
    
                ObjectList.Add(new TestObject(1));
                ObjectList.Add(new TestObject(10));
                ObjectList.Add(new TestObject(39));
    
            }
        }
    }
