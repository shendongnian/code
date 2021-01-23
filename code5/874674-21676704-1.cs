    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DataPRoviderTest
    {
        public class A
        {
            public static A Instance
            {
                get { return new A(); }
            }
    
            public Object SomeProperty
            {
                get { return "Hi there"; }
            }
        }
    
        public class B
        {
            public Object TheProperty
            {
                get { return tp; }
                set { tp = value; }
            } Object tp = null;
    
            public B(A instance)
            {
                TheProperty = instance.SomeProperty;
            }
        }
    }
