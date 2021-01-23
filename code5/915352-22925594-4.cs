    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    static Dictionary<TimeZoneInfo, string> GetCldrGenericLongNames(string basePath, string language)
    {
        // Set some file paths
        string winZonePath = basePath + @"\common\supplemental\windowsZones.xml";
        string metaZonePath = basePath + @"\common\supplemental\metaZones.xml";
        string langDataPath = basePath + @"\common\main\" + language + ".xml";
        // Make sure the files exist
        if (!File.Exists(winZonePath) || !File.Exists(metaZonePath) || !File.Exists(langDataPath))
        {
            throw new FileNotFoundException("Could not find CLDR files with language '" + language + "'.");
        }
        // Load the data files
        var xmlWinZones = XDocument.Load(winZonePath);
        var xmlMetaZones = XDocument.Load(metaZonePath);
        var xmlLangData = XDocument.Load(langDataPath);
        // Prepare the results dictionary
        var results = new Dictionary<TimeZoneInfo, string>();
        // Loop for each Windows time zone
        foreach (var timeZoneInfo in TimeZoneInfo.GetSystemTimeZones())
        {
            // Get the IANA zone from the Windows zone
            string pathToMapZone = "/supplementalData/windowsZones/mapTimezones/mapZone" +
                                   "[@territory='001' and @other='" + timeZoneInfo.Id + "']";
            var mapZoneNode = xmlWinZones.XPathSelectElement(pathToMapZone);
            if (mapZoneNode == null) continue;
            string primaryIanaZone = mapZoneNode.Attribute("type").Value;
            // Get the MetaZone from the IANA zone
            string pathToMetaZone = "/supplementalData/metaZones/metazoneInfo/timezone[@type='" + primaryIanaZone +  "']/usesMetazone";
            var metaZoneNode = xmlMetaZones.XPathSelectElements(pathToMetaZone).LastOrDefault();
            if (metaZoneNode == null) continue;
            string metaZone = metaZoneNode.Attribute("mzone").Value;
            // Get the generic name for the MetaZone
            string pathToNames = "/ldml/dates/timeZoneNames/metazone[@type='" + metaZone + "']/long";
            var nameNodes = xmlLangData.XPathSelectElement(pathToNames);
            var genericNameNode = nameNodes.Element("generic");
            var standardNameNode = nameNodes.Element("standard");
            string name = genericNameNode != null
                ? genericNameNode.Value
                : standardNameNode != null
                    ? standardNameNode.Value
                    : null;
            
            // If we have valid results, add to the dictionary
            if (name != null)
            {
                results.Add(timeZoneInfo, name);
            }
        }
        return results;
    }
