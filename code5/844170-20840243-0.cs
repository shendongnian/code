           foreach (ColumnHeader sColumnHeader in listView1.Columns)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == textBox1.Text)
                    {
                        listView1.Items[item.Index].UseItemStyleForSubItems = false;
                        listView1.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.LightBlue;
                    }
                }
            }
