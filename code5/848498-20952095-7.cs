                XmlDocument doc = new XmlDocument();
                XmlReaderSettings setting = new XmlReaderSettings();
                setting.CheckCharacters = false;
                setting.ProhibitDtd = false;
                setting.CheckCharacters = false;
                setting.IgnoreProcessingInstructions = true;
                
                var reader = XmlTextReader.Create("E:\\text.xml", setting);
                doc.Load(reader);
