    private void ReportUsage()
       {
           XmlDocument myXml = new XmlDocument();
           myXml.Load(historyXml);
           string list = historyXml;
           jumpList.ClearAllUserTasks();
           foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
           {
               string s = el.GetAttribute("url");
               JumpListLink jll = new JumpListLink(Assembly.GetEntryAssembly().Location, s);
               jll.IconReference = new IconReference(Path.Combine("C:\\Program Files\\ACS Digital Media\\TOC WPF Browser\\Icon1.ico"), 0);
               jll.Arguments = el.GetAttribute("url");
               jumpList.AddUserTasks(jll);
           }
           jumpList.Refresh();
       }
