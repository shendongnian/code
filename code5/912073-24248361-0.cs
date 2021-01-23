                var indices = new int[] { 0, 1, 2, 8, 9, 15, 19, 22, 23, 24, 25 };
                foreach (ListViewItem lvi in lvData.Items)
                {
                    i = 1;
                    int bol = lvi.SubItems.Count;
                    foreach (int id in indices)
                    { 
                        if (bol > 0)
                        {
                           ws.Cells[i2, i] = lvi.SubItems[id].Text;
                           i++;
                           bol--;
                        }
                    }
                    i2++;
                }
