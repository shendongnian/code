    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace ConsoleApp5 {
        public class Program {
            public static void Main(string[] args) {
                string test = getValuesOneFile("xmltest.xml");
                Console.WriteLine(test);
                Console.ReadLine();
            }
            public static string getValuesOneFile(string fileName) {
                string finalString = "";
                XElement xmlDocument = XElement.Load((fileName));
                XElement infoImgDir = GetImgDir(xmlDocument, "info");
                finalString += "[" + GetInt(infoImgDir, "returnMap") + "]\n";
                finalString += "total=" + GetChildrenCount(GetImgDir(xmlDocument,"portal")) + "\n";
                IEnumerable<XElement> portals = GetImgDir(xmlDocument, "portal").Elements();
                foreach (XElement currentPortal in portals) {
                    finalString += GetString(currentPortal, "pn") + " ";
                    finalString += GetInt(currentPortal, "pt") + " ";
                    finalString += GetInt(currentPortal, "x") + " ";
                    finalString += GetInt(currentPortal, "y") + " ";
                    finalString += GetInt(currentPortal, "tm") + "\n";
                }
                return finalString;
            }
            public static XElement GetImgDir(XElement file, string imgDirName) {
                return file.Descendants("imgdir").FirstOrDefault(x => (string)x.Attribute("name") == imgDirName);
            }
            public static int GetInt(XElement data, string attribName) {
                var element = data.Descendants("int").FirstOrDefault(x => (string)x.Attribute("name") == attribName);
                if (element == null)
                    return 0;
                var value = (int?)element.Attribute("value");
                if (value == null)
                    return 0;
                return value.Value;
            }
            public static string GetString(XElement data, string attribName) {
                var element = data.Descendants("string").FirstOrDefault(x => (string)x.Attribute("name") == attribName);
                if (element == null)
                    return "";
                var value = (string)element.Attribute("value");
                if (value == null)
                    return "";
                return value;
            }
            public static int GetChildrenCount(XElement data) {
                return data.Elements().Count();
            }
        }
    }
