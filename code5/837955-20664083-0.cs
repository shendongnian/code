    foreach (XElement element in USshardStatus.Descendants().
        Where(x => x.Name.LocalName == "status").
        Descendants().
        Where(y => y.Name.LocalName == "shart"))
            {
                //Add items to your listviews.
                string onlineValue = element.Elements().Where(x => x.Name.LocalName == "online").SingleOrDefault().Value;
                string name = element.Elements().Where(x => x.Name.LocalName == "name").SingleOrDefault().Value;
                //So on...
                string[] row = {onlineValue, name};
                listView.Items.Add(new ListViewItem(row));
            }
