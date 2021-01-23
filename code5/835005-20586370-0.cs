    private void doSomething(String q)
        {
            try
            {
                cn.Open();
                cmd.CommandText = "update Table1 set [name]=@name  where id=@id";
                cmd.Parameters.AddWithValue("@name",textBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@id",listBox1.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                cn.Close();
                loaddata();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
        }
               
