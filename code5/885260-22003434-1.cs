    using System;
    using System.Collections.Generic;
    
    namespace sortVolumen
    {
    class Program
    {
        static void Main(string[] args)
        {
            List<box> BoxList = new List<box> { 
                new box { Width = 2, Height = 2, Depth = 2},
                new box { Width = 3, Height = 3, Depth = 3},
                new box { Width = 1, Height = 1, Depth = 1},
            };
            foreach (box myBox in BoxList)
            {
                Console.WriteLine(myBox.Volumen);
            }
            BoxList.Sort(delegate(box a, box b) { return a.Volumen < b.Volumen ? -1 : 1;});
                Console.WriteLine("after comparing");
                foreach (box myBox in BoxList)
                {
                    Console.WriteLine(myBox.Volumen);
                }
                Console.ReadLine();
            }
        }
        class box
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double Depth { get; set; }
            public double Volumen {
                get { return Width * Height * Depth; }
            }
        }
    }
