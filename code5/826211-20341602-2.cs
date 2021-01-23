    //Enter event handler for listView1
    private void listView1_Enter(object sender, EventArgs e){
      foreach(ListViewItem item in listView1.Items){
        item.BackColor = SystemColors.Window;
        item.ForeColor = SystemColors.WindowText;
      }
    }
