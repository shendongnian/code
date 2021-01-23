    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Get the XML doc from a file, similarly you can get it from a string or stream.
                var doc = XDocument.Load("file.xml");
                // Use linq style to get to the first Settings element or throw
                var settings = doc.Elements("Settings").Single().Elements();
                // Get root nodes for the settings type, if there is more than one ignore the rest and grab the first.
                // Change the logic to throw or combine to match the rules for your app
                var generalOptions = settings.FirstOrDefault(e => e.Name.LocalName == "General");
                var advancedOptions = settings.FirstOrDefault(e => e.Name.LocalName == "Advanced");
                var generalSettings = ExtractOptions(generalOptions);
                var advancedSettings = ExtractOptions(advancedOptions);
            }
            private static Settings ExtractOptions(XElement rootElement)
            {
                var settings = new Settings();
                if (rootElement != null)
                {
                    var elements = rootElement.Elements();
                    settings.Options = elements.Where(e => e.Name.LocalName.IndexOf("Option", StringComparison.OrdinalIgnoreCase) >= 0)
                                               .Select(e => int.Parse(e.Value))
                                               .ToArray();
                    settings.CheckBoxes = elements.Where(e => e.Name.LocalName.StartsWith("CheckBox", StringComparison.OrdinalIgnoreCase))
                                                  .Select(e => bool.Parse(e.Value))
                                                  .ToArray();
                }
                return settings;
            }
            public class Settings
            {
                public int[] Options { get; set; }
                public bool[] CheckBoxes { get; set; }
            }
        }
    }
