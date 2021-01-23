            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    if (listView1.SelectedItems[i].Selected)   
                    {
                        int i2 = listView1.SelectedItems[i].Index;
                        item = listView1.Items[i2].Text;
                        sColl.Add(item);
                    }
                }
            }
            listView1.SelectedItems.Clear();
            foreach (var itemS in sColl)
            {
                string items = itemS;
            }
            sColl.Clear();
            listView1.SelectedItems.Clear();
