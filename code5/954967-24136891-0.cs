     if (listView1.Items.Count == 0) return;
                var col = listView1.Columns.Cast<ColumnHeader>()
                                    .Select((x, i) => new { x, i })
                                    .FirstOrDefault(a => a.x.Text == "ID");
                if (col == null) return;
                foreach (ListViewItem item in listView1.Items)
                {
                    item.SubItems[col.i].Text = "";
                }
                int newID = listView1.Items.Count;
                for (int i = 1; i <= newID; i++)
                {
                    listView1.Items[i-1].SubItems[0].Text = i.ToString();
                }
