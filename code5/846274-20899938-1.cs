     public string SelectedStudentId { get; set; }
     private void listView1_DoubleClick(object sender, EventArgs e)
     {
        var cl = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text;
        SelectedStudentId = cl;
    	DialogResult = DialogResult.OK; //will close this dialog (form2)
     }
