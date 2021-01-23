    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;
    using System.Xml;
    namespace UShort
    {
    class Program
    {
        static void Main(string[] args)
        {
            Products prod = new Products();
            prod.Cloths = new List<Products.cloths>();
            Products.cloths jacket = new Products.cloths();
            jacket.ClothName = "MyJacket";
            jacket.amount = 12345;
            jacket.price = (float)123.45;
            jacket.size = 12;
            jacket.images = "c:\\asdasd.jpg";
            prod.Cloths.Add(jacket);
            // String contining XML. Do what you want with it.
            string ProductXML = XMLTools.convertObjToXMLString(prod);   
            // Create an object from an XML string of the same format.
            Products NewProduct = (Products)XMLTools.convertXMLStringToObject(ProductXML, typeof(Products));
        }
        public class Products
        {
            public List<cloths> Cloths = new List<cloths>();
            public class cloths
            {
                public string ClothName = string.Empty;
                public int size = 0;
                public float price = 0;
                public long amount = 0;
                public string images = string.Empty;
            }
        }
        public static class XMLTools
        {
            /// <summary>
            /// Overwrites the encoding to use UTF-8
            /// </summary>
            private class Utf8StringWriter : StringWriter
            {
                public override Encoding Encoding
                {
                    get { return Encoding.UTF8; }
                }
            }
            public static string convertObjToXMLString(object obj)
            {
                try
                {
                    XmlSerializer serObj = new XmlSerializer(obj.GetType());
                    Utf8StringWriter sw = new Utf8StringWriter();
                    XmlTextWriter xtw = new XmlTextWriter(sw);
                    xtw.Formatting = Formatting.Indented;
                    serObj.Serialize(xtw, obj);
                    return sw.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public static object convertXMLStringToObject(string xmlString, Type objectType)
            {
                try
                {
                    TextReader txr = new StringReader(xmlString);
                    XmlSerializer serObj = new XmlSerializer(objectType);
                    return serObj.Deserialize(txr);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
