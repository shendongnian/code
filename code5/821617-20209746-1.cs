    int lastIndex;
    private void timer1_Tick(object sender, EventArgs e)
    {
        this.Refresh();
        int i = listView1.TopItem == null ? -1 : listView1.TopItem.Index;        
        if(i>-1) {
          if(i == lastIndex || i == listView1.Items.Count - 2) i = 0;
          lastIndex = i;
          listView1.TopItem = listView1.Items[++i];
        }
    }
