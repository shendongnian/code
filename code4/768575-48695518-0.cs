    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Data;
    using System.Xml.Serialization;
    namespace Generics
    {
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public int legs { get; set; }
        public bool tail { get; set; }
    }
    class Program
    {
        public static DataTable CreateDataTable(Object[] arr)
        {
            XmlSerializer serializer = new XmlSerializer(arr.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, arr);
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
            ds.ReadXml(reader);
            return ds.Tables[0];
        }
        static void Main(string[] args)
        {
            Dog Killer = new Dog();
            Killer.Breed = "Maltese Poodle";
            Killer.legs = 3;
            Killer.tail = false;
            Killer.Name = "Killer";
            Dog [] array_dog = new Dog[5];
            Dog [0] = killer;
            Dog [1] = killer;
            Dog [2] = killer;
            Dog [3] = killer;
            Dog [4] = killer;
            DataTable dogTable = new DataTable();
            dogTable = CreateDataTable(array_dog);
            // continue here
            }      
        }
    }
