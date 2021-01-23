    using System;
    
    class Program {
        static void Main(string[] args) {
            Action d = null;
            d = new Action(() => {
                d.BeginInvoke(null, null);
            });
            d();
            Console.ReadLine();
        }
    }
