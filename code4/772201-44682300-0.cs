    using System;
    using System.Xml.Linq;
    using System.Web;
    namespace YourProjectName
    {
        public static class XmlFileRetrieve
        {
            public static string GetParameterValue(string name)
            {
                try
                {
                    string path = HttpContext.Current.Server.MapPath("~/YourFolderName/YourXmlFileName.xml");
                    XDocument doc = XDocument.Load(path);
                    if (!(doc == null))
                    {
                        var parameter = (from el in doc.Root.Elements("Parameter")
                                    where (string)el.Attribute("Name") == name
                                    select (string)el.Attribute("value")).Select(keyvalue => new { name = keyvalue }).Single(); ;
                        return parameter.name;
                    }
                    return "";
                }
                catch (Exception e)
                {string error=e.Message;return "";
                }
            }
        }
    }
