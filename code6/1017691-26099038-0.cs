    //MyData.cs
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FixedLengthFileReader
    {
        class MyData
        {
            [Layout(0, 10)]
            public string field1;
            [Layout(10, 4)]
            public int field2;
            [Layout(14, 8)]
            public double field3;
    
            public override String ToString() {
                return String.Format("String: {0}; int: {1}; double: {2}", field1, field2, field3);
            }
        }
    }
