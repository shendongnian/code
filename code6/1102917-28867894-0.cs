        if (listView1.InvokeRequired)
        {
            listView1.BeginInvoke(new MethodInvoker(() =>
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    Items.Add(listView1.Items[i].SubItems[0].Text.ToString());
                    Items.Add(listView1.Items[i].SubItems[1].Text.ToString());
                }
            }));
            return Items;
        }
