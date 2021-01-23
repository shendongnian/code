    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace Sender
    {
        class Program
        {
            static void Main(string[] args)
            {
                Diagram diagram = new Diagram
                {
                    Title = "Flowchart",
                    Shapes = new List<IShape>
                    {
                        new Circle 
                        { 
                            Id = 1, 
                            Text = "Foo", 
                            Center = new Point { X = 1, Y = 5 }, 
                            Radius = 1.25 
                        },
                        new Line 
                        {
                            Id = 2,
                            A = new Point { X = 2.25, Y = 5 }, 
                            B = new Point { X = 4, Y = 5 } 
                        },
                        new Rectangle
                        {
                            Id = 3,
                            Text = "Bar",
                            TopLeft = new Point { X = 4, Y = 6.5 }, 
                            BottomRight = new Point { X = 8.5, Y = 3.5 } 
                        }
                    }
                };
    
                string json = JsonConvert.SerializeObject(diagram, Formatting.Indented);
    
                File.WriteAllText(@"C:\temp\test.json", json);
            }
        }
    
        class Diagram
        {
            public string Title { get; set; }
            public List<IShape> Shapes { get; set; }
        }
    
        interface IShape
        {
            int Id { get; set; }
            string Text { get; set; }
        }
    
        abstract class AbstractShape : IShape
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
    
        class Line : AbstractShape
        {
            public Point A { get; set; }
            public Point B { get; set; }
        }
    
        class Rectangle : AbstractShape
        {
            public Point TopLeft { get; set; }
            public Point BottomRight { get; set; }
        }
    
        class Circle : AbstractShape
        {
            public Point Center { get; set; }
            public double Radius { get; set; }
        }
    
        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
    }
