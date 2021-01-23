    string val = SettingFromXML(
        @"<!--VM settings on ESX Server-->                
        <VM name=""DE-2K8"" language=""de"" powerOn=""true"">
            <vmClients>
                <vmClient name=""ITXP"" language=""it""/>
            </vmClients>
            <guest>
                <browser value = ""firefox""/>
                <language value = ""de""/>
            </guest>
        </VM>
        <VM name=""EN2008"" language=""en"" powerOn=""true"">
            <vmClients>
                <vmClient name=""IT-2K8R2ENT64X"" language=""it""/>
            </vmClients>
            <guest>
                <browser value = ""chrome""/>
                <language value = ""en""/>
            </guest>
        </VM>", "EN2008", "guest", "language"
    );
    MessageBox.Show(val);
    public static string SettingFromXML(string xml, string systemName, string section, string name) {
        xml = "<VMSettings>" + xml + "</VMSettings>"; // wrap XML in root node to deal with multiple root node exception
        using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(xml))) {
            XDocument xDoc = XDocument.Load(ms);
            return xDoc.Descendants("VMSettings")
                       .Descendants("VM").First(el1 => el1.Attribute("name").Value == systemName)
                       .Descendants().First(el2 => el2.Name == section)
                       .Descendants().First(el3 => el3.Name == name).Attribute("value").Value;                
        }                
    }
