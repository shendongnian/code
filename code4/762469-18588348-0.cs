    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class Parent {
        public Dictionary<string, int> WantToIgnoreThis { get; set; }
    }    
    public class Child : Parent {
        public int Foo { get; set; }
    }
    static class Program
    {
        static readonly XmlSerializer customSerializer;
    
        static Program()
        {
            var xao = new XmlAttributeOverrides();
            xao.Add(typeof(Parent), "WantToIgnoreThis", new XmlAttributes {
                XmlIgnore = true
            });
            customSerializer = new XmlSerializer(typeof(Child), xao);
        }
        static void Main()
        {
            //var ser = new XmlSerializer(typeof(Child));
            // ^^ this would fail
    
            customSerializer.Serialize(Console.Out, new Child {
                Foo = 123
            });
        }
    }
