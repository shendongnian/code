    using System;
    
    class Program {
        static void Main(string[] args) {
            var tablets = new TouchTabletCollection();
            for (int ix = 0; ix < tablets.Count; ++ix) {
                Console.WriteLine("Found tablet {0} named {1}", ix + 1, tablets[ix].Name);
                Console.WriteLine("  Type = {0}, Multi-touch supported = {1}", tablets[ix].Kind, tablets[ix].IsMultiTouch);
                Console.WriteLine("  Input rectangle  = {0}", tablets[ix].InputRectangle);
                Console.WriteLine("  Screen rectangle = {0}", tablets[ix].ScreenRectangle);
            }
            Console.ReadLine();
        }
    }
