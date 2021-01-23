    private void listView1_DoubleClick(object sender, EventArgs e)
    {
       var cl = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text;
       Form1.StudentIDVal = cl.ToString();
       this.Close();
    }
