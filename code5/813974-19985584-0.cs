    private void button7_Click(object sender, EventArgs e)
    {
       ListViewItem lvi = new ListViewItem(); 
       foreach (object o in MaxLen)
       {
          lvi.SubItems.Add(o.ToString());
       }
       
       foreach (object a in SeqIrregularities)
       {
          lvi.SubItems.Add(a.ToString()); 
       }
       foreach (object b in PercentPopList)
       {
          lvi.SubItems.Add(b.ToString()); 
       }
    
    ListView1.Items.Add(lvi);//here you need to add
    }
