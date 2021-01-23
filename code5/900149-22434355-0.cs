    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MyLibraryProject
    {
        public class MathLibraryClass
        {
            public int num1 { get; set; }
            public int num2 { get; set; }
            public int Sum(int n1,int n2)
            {
                num1 = n1;
                num2 = n2;
                return num1 + num2;
            }
        }
    }
