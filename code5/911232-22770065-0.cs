    for (int i = 0; i < listBox1.SelectedItems.Count; i++)
    {
       ad.InsertCommand = new OleDbCommand("insert into Map_Data (Material_Code,Product_Id) values(@Material_Code,@Product_Id)", con);
       ad.InsertCommand.Parameters.Add("@Material_Code", OleDbType.Integer).Value =Convert.ToInt32(listBox1.SelectedValue);
       listBox1.Items.Remove(listBox1.SelectedItem);
       ad.InsertCommand.Parameters.Add("@Product_Id", OleDbType.Integer).Value = count;
            
       con.Open();
       ad.InsertCommand.ExecuteNonQuery();
       con.Close();
    }
    MessageBox.Show("Record is successfully Save In The Database");
