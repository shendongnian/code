    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleTest
    {
        class Program
        {
            public delegate void Visitor(int i);
            public static void visitorTest(Visitor visitor){
                int[] tmp = new int[10];
                for (int i = 0; i < tmp.Length; i++){
                    tmp[i] = i;
                }
                foreach(var i in tmp){
                    visitor(i);
                }
            }
            public static void funcCallback(int arg) {
                System.Console.WriteLine("func: " + arg.ToString());
            }
            static void Main(string[] args)
            {
                visitorTest(funcCallback);
    
                int mul = 2;
    
                visitorTest((int i)=>{System.Console.WriteLine("lambda: " + (mul*i).ToString());});
    			Action<int> lambda = (int i) => { System.Console.WriteLine("lambda: " + (3 * i).ToString()); };
    			visitorTest(lambda.Invoke);
            }
        }
    }
