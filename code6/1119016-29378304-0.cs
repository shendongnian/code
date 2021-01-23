    string[] lines = File.ReadAllLines("");
    for(int i = 0; i < lines.Length; i= i + 8)
           {
               ListViewItem lvi = new ListViewItem();
                   lvi.Text = line[i]; 
                   lvi.SubItems.Add(line[i+1]);
                   lvi.SubItems.Add(line[i+2]);
                   lvi.SubItems.Add(line[i+3]);
                   lvi.SubItems.Add(line[i+4]);
                   lvi.SubItems.Add(line[i+5]);
                   lvi.SubItems.Add(line[i+6]);
                   lvi.SubItems.Add(line[i+7]);
                   listView1.Items.Add(lvi);
           }
