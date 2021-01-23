    using System;
    using System.Collections.Generic;
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                IColorResolver colors = new ColorResolver();
                IObject demoObject1 = new Object(1, 1, 1, 1, colors);
                IObject demoObject2 = new Object(2, 3, 3, 3, colors);
                Console.WriteLine("demoObject1: {0}", demoObject1.Color.Name);
                Console.WriteLine("demoObject2: {0}", demoObject2.Color.Name);
                Console.ReadKey();
            }
        }
        public interface IObject
        {
            int Id { get; }
            ISize Size { get; set; }
            IColor Color { get; set; }
            IAuthor Author { get; set; }
        }
        public class Object: IObject
        {
            bool isDirty = false;
            readonly int id;
            int size;
            int color;
            int author;
            IColorResolver colors;
            public int Id { get { return this.id; } }
            public ISize Size { get; set; } //this would implement code like Color's
            public IAuthor Author { get; set; }//this would implement code like Color's
            public IColor Color
            {
                get { return colors.GetColor(color); }
                set
                {
                    if (!this.color.Equals(value.Id))
                    {
                        this.color = value.Id;
                        this.isDirty = true;
                    }
                }
            }
            public Object(int id, int size, int color, int author, IColorResolver colorResolver)
            {
                this.id = id;
                this.size = size;
                this.color = color;
                this.author = author;
                this.colors = colorResolver;
            }
            // add, update, delete methods
        }
        
        public interface ILookupValue
        {
            int Id { get; }
            string Name { get; /*set;*/ } //no set since this is a lookup so we don't want to amend it
        }
        public interface IColor: ILookupValue
        {
            IColorResolver GetResolver();
        }
        public interface IAuthor : ILookupValue { /* ... */ }
        public interface ISize : ILookupValue { /* ... */ }
    
        public class Color : IColor
        {
            int id;
            string name;
            IColorResolver colors;
            public int Id { get { return this.id; } }
            public string Name { get { return this.name; } }
            public Color(int id, string name, IColorResolver colors)
            {
                this.id = id;
                this.name = name;
                this.colors = colors;
                this.colors.AddColor(this);
            }
            public IColorResolver GetResolver() { return this.colors; }
        }
    
        public interface IColorResolver
        {
            IColor GetColor(int id);
            void AddColor(IColor color);
        }
        public class ColorResolver : IColorResolver
        {
            IDictionary<int, IColor> colors = new Dictionary<int, IColor>();
            public ColorResolver()
            {
                /*
                 in reality you'd probably pass a data layer object through 
                 the constructor to fetch these values from your database 
                */
                new Color(1, "Red", this);
                new Color(2, "Green", this);
                new Color(3, "Blue", this);
            }
            public void AddColor(IColor color)
            {
                this.colors.Add(color.Id, color);
            }
            public IColor GetColor(int id)
            {
                IColor result;
                this.colors.TryGetValue(id, out result); //you could throw an exception here if not found
                return result;
            }
        }
    }
