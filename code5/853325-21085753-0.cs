       private void btnDelete_Click(object sender, EventArgs e)
        {
            
          //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM tb1 WHERE name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", txtproject_name.Text);
         
            cmd.ExecuteNonQuery();
            Bind();
            MessageBox.Show("deleted......");
            con.Close();
            }
