    using System.Xml.Linq;
    class ExternalRMStrings
    {
        public static bool allAtOnce = true;
        //static string path = @"C:\WOI\Code\VC Days are here again\Ode to Duty\WinForms\Globalization\MultiLingual\MultiLingual\Resource_Hindi.resx";
        //@"d:\Resources.resx";
        static string path = @"C:\WOI\Code\VC Days are here again\Ode to Duty\WinForms\Globalization\MultiLingual\MultiLingual\Properties\Resources.resx";
        static XElement xelement = XElement.Load(path);
        static IEnumerable<XElement> employees = null;
        static Dictionary<string, string> dicOfLocalizedStrings = new Dictionary<string, string>();
        static void LoadAllAtOnce()
        {
            if (employees == null) employees = xelement.Elements();
            employees.Where(e => e.Name == "data").Select(x => x).All(xele =>
            {
                dicOfLocalizedStrings[xele.Attribute("name").Value] = xele.Element("value").Value;
                return true;
            });
        }
        public static string GetString(string key)
        {
            if (employees == null) employees = xelement.Elements();
            if (allAtOnce) LoadAllAtOnce();
            try
            {
                string sibla = null;
                if (dicOfLocalizedStrings.TryGetValue(key, out sibla)) return sibla;
                sibla = employees.Where(e => e.Name == "data" && e.Attribute("name").Value == key).Select(x => x.Element("value").Value).FirstOrDefault();
                dicOfLocalizedStrings[key] = sibla;
                return sibla;
            }
            catch
            {
                return null;
            }
        }
    }
