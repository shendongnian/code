    if(textBox1.Text.trim()=="")
    {
    
     MessageBox.Show("Please enter Student ID", "Delete Failed",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);       
    }
    cmd.ExecuteNonQuery();}
