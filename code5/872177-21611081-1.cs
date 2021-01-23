    var pic = File.ReadAllBytes(yourFileName);
    using(OleDbConnection con = new OleDbConnection(constr))
    using(OleDbCommand cmd = new OleDbCommand("Insert Into DML_Books_List(ID, [Image]) values (@id, @image)", con))
    {
        con.Open();
        cmd.Parameters.AddWithValue("@id", TextBox1.Text);
        cmd.Parameters.AddWithValue("@image", pic);
        cmd.ExecuteNonQuery();
    }
