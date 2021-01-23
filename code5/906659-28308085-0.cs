    private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SqlConnection sql = new SqlConnection("Your String Connection");
                SqlDataAdapter adapter = new SqlDataAdapter(@"Select Name, FileName From Table Where Name Like @Name", sql); //For Name
                adapter.SelectCommand.Parameters.AddWithValue("@Name", string.Format("%{0}%", textBox1.Text));
                SqlDataAdapter adapter_1 = new SqlDataAdapter(@"Select Name, FileName From Table Where FileName Like @FileName", sql); //For FileName
                adapter_1.SelectCommand.Parameters.AddWithValue("@FileName", string.Format("%{0}%", textBox2.Text));    
            }
        }
 
