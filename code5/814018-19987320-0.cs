            ListViewItem lvi = new ListViewItem(); 
            foreach (object o in SeqIrregularities )
            {
                lvi.SubItems.Add(o.ToString());
            }
            listView1.Items.Add(lvi);//Adds a new row
            lvi = new ListViewItem();
 
            foreach (object a in MaxLen )
            {
                lvi.SubItems.Add(a.ToString()); 
            }
            listView1.Items.Add(lvi);//Adds a new row
            lvi = new ListViewItem();
            foreach (object b in PercentPopList)
            {
                lvi.SubItems.Add(b.ToString()); 
            }
            listView1.Items.Add(lvi);//Adds a new row
