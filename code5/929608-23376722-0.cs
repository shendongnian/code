    [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
    public static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);
    public static List<string> GetMetroAppnames() {
                List<string> names = new List<string>();
    
                foreach(string dir in Directory.GetDirectories(@"c:\program files\WindowsApps\")) {
                    if(System.IO.File.Exists(dir + @"\AppxManifest.xml")) {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(dir + @"\AppxManifest.xml");
    
                        if(doc.GetElementsByTagName("Framework")[0] != null)
                            if(doc.GetElementsByTagName("Framework")[0].InnerText.ToLower() == "true")
                                continue;
                        if(doc.GetElementsByTagName("Protocol")[0] == null) continue;
    
                        string name = doc.GetElementsByTagName("DisplayName")[0].InnerText;
                        string identity = doc.GetElementsByTagName("Identity")[0].Attributes["Name"].Value;
                        string appName = "";
    
                        if(!name.Contains("ms-resource")) {
                            names.Add(name);
                        } else {
                            if(doc.GetElementsByTagName("Application").Count > 1) {
                                foreach(XmlElement elem in doc.GetElementsByTagName("Application")) {
                                    name = elem.GetElementsByTagName("m2:VisualElements")[0].Attributes["DisplayName"].Value;
                                    if(name.Contains("AppName")) name = name.Replace("AppName", "AppTitle");
                                    appName = GetName(dir, name, identity);
                                    if(appName != "") names.Add(appName);
                                }
                            }
                            appName = GetName(dir, name, identity);
                            if(appName != "") names.Add(appName);
                        }
                    }
                }
                return names.Distinct().ToList();
            }
    private static string GetName(string dir, string name, string identity) {
            StringBuilder sb = new StringBuilder();
            int result;
            
            result = SHLoadIndirectString(
                @"@{" + Path.GetFileName(dir) + "? ms-resource://" + identity + "/resources/" + name.Split(':')[1] + "}",
                sb, -1,
                IntPtr.Zero
            );              
            if(result == 0) return sb.ToString();
            return "";
        }
