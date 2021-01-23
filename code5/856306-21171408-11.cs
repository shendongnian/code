    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace TestBench{
        class Program{
            static void Main(string[] args){
            float f = 0.0F;
            int Y = 0;
    
            for (int i = 0; i < 10; i++) {
                f += 0.41F;
                Y = Convert.ToInt32(f);
    
                Debug.WriteLine("Float: " + f + " Int32 " + Y);
    
            }
    
            }
        }
    }
