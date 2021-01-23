     protected string[] Config()
            {
                var retStrings = new[] {"","","",""};
                var xd = new XmlDocument();
                var fs = new FileStream("data/config.xml", FileMode.Open);
                xd.Load(fs);
    
                var list = xd.GetElementsByTagName("Config");
                for (var i = 0; i < list.Count; i++)
                {
                    retStrings[0] = xd.GetElementsByTagName("port")[i].InnerText;
                    retStrings[1] = xd.GetElementsByTagName("thread")[i].InnerText;
                    retStrings[2] = xd.GetElementsByTagName("gSave")[i].InnerText;
                    retStrings[3] = xd.GetElementsByTagName("bSave")[i].InnerText;
                }
    
                fs.Close();
    
                return retStrings;
            }
