            string url = "http://www.test.com/feed/";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Title");
            foreach (SyndicationItem item in feed.Items)
            {
                DataRow row = tbl.NewRow();
             
                String title= item.Title.Text;
                row["Title"]= title;
                table.Rows.Add(row);   
            }
