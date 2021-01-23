    protected void Button1_Click(object sender, EventArgs e)
    {
        int selectedRowIndex = GridView1.SelectedIndex;
        foreach(var row in GridfView1.Rows)
        {
           if(row.Index!=selectedRowIndex)
           {
             if(row.Cells["IndexOfColumn"].Text==TextBox.Text))
             {
                 // Do what you want here
             }
           }
        }
    }
        
