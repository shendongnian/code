            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath);
           
            DataTable dt = new DataTable();
            foreach (XmlNode xn in doc.ChildNodes[0])
            {
                string tagName = xn.Name;
                if (!dt.Columns.Contains(tagName))
                {
                    dt.Columns.Add(tagName);
                }
               
            }
            DataRow dr = dt.NewRow();
            foreach (XmlNode xn in doc.ChildNodes[0])
            {
                dr[xn.Name] = xn.InnerText;
               
            }
            dt.Rows.Add(dr);
