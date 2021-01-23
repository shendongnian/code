        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        namespace RectangleApplication
        {
            public class Rectangle
            {
                public double width;
                public double length;
                public double GetArea()
                {
                    return width * length;
                }
                public void Display()
                {
                    Console.WriteLine("Lenght:{0}", length);
                    Console.WriteLine("Width: {0}", width);
                    Console.WriteLine("Area: {0}", GetArea());
                }
            }
            public class ExecuteRectangle
            {
                public static void Main(string[] args)
                {
                    Rectangle r = new Rectangle();
                    r.length = 3.5;
                    r.width = 4.5;
                    r.Display();
                    Console.ReadLine();
                }
            }
        }
