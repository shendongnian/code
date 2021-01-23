    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace Receiver
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = File.ReadAllText(@"C:\temp\test.json");
    
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters.Add(new FigureConverter());
                Chart chart = JsonConvert.DeserializeObject<Chart>(json, settings);
    
                Console.WriteLine(chart);
                Console.ReadKey();
            }
        }
    
        class FigureConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(IFigure));
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                if (jo["Center"] != null)
                {
                    return jo.ToObject<Circle>(serializer);
                }
                else if (jo["TopLeft"] != null)
                {
                    return jo.ToObject<Rectangle>(serializer);
                }
                else
                {
                    return jo.ToObject<Line>(serializer);
                }
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    
        class Chart
        {
            public string Title { get; set; }
            public List<IFigure> Shapes { get; set; }
    
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Chart: ");
                sb.AppendLine(Title);
                foreach (IFigure figure in Shapes)
                {
                    sb.AppendLine(figure.ToString());
                }
                return sb.ToString();
            }
        }
    
        interface IFigure
        {
            int Id { get; set; }
            string Text { get; set; }
        }
    
        abstract class AbstractFigure : IFigure
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
    
        class Line : AbstractFigure
        {
            public Point A { get; set; }
            public Point B { get; set; }
            public override string ToString()
            {
                return string.Format("Line: A = {0}, B = {1}", A, B);
            }
        }
    
        class Rectangle : AbstractFigure
        {
            public Point TopLeft { get; set; }
            public Point BottomRight { get; set; }
            public override string ToString()
            {
                return string.Format("Rectangle: TopLeft = {0}, BottomRight = {1}", TopLeft, BottomRight);
            }
        }
    
        class Circle : AbstractFigure
        {
            public Point Center { get; set; }
            public double Radius { get; set; }
            public override string ToString()
            {
                return string.Format("Circle: Center = {0}, Radius = {1}", Center, Radius);
            }
        }
    
        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public override string ToString()
            {
                return string.Format("({0:0.##}, {1:0.##})", X, Y);
            }
        }
    }
