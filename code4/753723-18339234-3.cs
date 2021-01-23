    int selected = -1;
    bool suppressSelectedIndexChanged;
    private void timer1_Tick(object sender, EventArgs e)
    {
      listView1.SuspendLayout();                
      if (selected > -1){
         ListViewItem item = listView1.Items[selected];
         Rectangle rect = listView1.GetItemRect(item.Index);
         suppressSelectedIndexChanged = true;                    
         item.Selected = item.Focused = !(rect.Top <= 2 || rect.Bottom >= listView1.ClientSize.Height-2);
         suppressSelectedIndexChanged = false;
      }
      listView1.VirtualListSize++;
      listView1.ResumeLayout(true);
    }
    private void listView1_SelectedIndexChanged(object sender, EventArgs e){
       if (suppressSelectedIndexChanged) return;
       selected = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;
    }
