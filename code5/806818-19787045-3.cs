    using System;
    using System.IO;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    class Program
    {
        public static void Main()
        {
            CultureAndRegionInfoBuilder cib = null;
            try
            {
                // Create a CultureAndRegionInfoBuilder 
                // object named "ro-MD".
                cib = new CultureAndRegionInfoBuilder(
                                        "ro-MD", CultureAndRegionModifiers.None);
                // Populate the new CultureAndRegionInfoBuilder 
                // object with culture information.
                CultureInfo ci = new CultureInfo("ro-RO");
                cib.LoadDataFromCultureInfo(ci);
                // Populate the new CultureAndRegionInfoBuilder 
                // object with region information.
                RegionInfo ri = new RegionInfo("RO");
                cib.LoadDataFromRegionInfo(ri);
                var filePath = "ro-MD.xml";
                if (File.Exists(filePath))
                    File.Delete(filePath);
                // Save as XML
                cib.Save(filePath);
                // TODO: modify the XML
                var xDoc = XDocument.Load(filePath);
                var ns = 
                    "http://schemas.microsoft.com/globalization/2004/08/carib/ldml";
                xDoc.Descendants(XName.Get("regionEnglishName", ns))
                    .FirstOrDefault().Attribute("type").SetValue("Moldova");
                xDoc.Descendants(XName.Get("regionNativeName", ns))
                    .FirstOrDefault().Attribute("type").SetValue("Moldova");
                // and so on
                xDoc.Save(filePath);
                var roMd = CultureAndRegionInfoBuilder
                    .CreateFromLdml(filePath);
                // this may throw an exception if the culture info exists 
                try
                {
                    CultureAndRegionInfoBuilder.Unregister("ro-MD");
                }
                catch (Exception)
                {
                    //throw;
                }
                // Register the custom culture.
                roMd.Register();
                // Display some of the properties of the custom culture.
                var riMd = new RegionInfo("ro-MD");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
