    private void AddNewRowMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            job pipainput = new job(JobsDataGrid.Items.Count+1,"",0,"");
            XmlSerializer xmls = new XmlSerializer(typeof(job));
            var sb = new StringBuilder(512);
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
                {
                    xmls.Serialize(sw, pipainput);
                }
            XmlDocument xmlk = new XmlDocument();
            xmlk.LoadXml(sb.ToString());
            XmlNode pipa = XMLData.Document.ImportNode(xmlk.ChildNodes[1], true);
            XMLData.Document.DocumentElement.AppendChild(pipa);
        }    
