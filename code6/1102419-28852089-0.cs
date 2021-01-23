    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
    foreach(var row in tblUser.Rows)
     {
       var tempcheckBox= row.Controls[0] as CheckBox;
       if(tempcheckBox.IsChecked)
        {//your code}
     }
    }
