    string cs = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=access.mdb";
    OleDbConnection c = new OleDbConnection(cs);
    string Name = txtName.Text;
    string PW = txtHash.Text;
    string Salt = txtSalt.Text;
    try
    {
        c.Open();
        string s = "INSERT INTO regulate(NAME, PASSWORD, SALT) Values (@NAME, @PASSWORD, @SALT)";
        using (OleDbCommand cmd = new OleDbCommand(s, c))
        {
            cmd.Parameters.AddWithValue("@NAME", Name);
            cmd.Parameters.AddWithValue("@PASSWORD", PW);
            cmd.Parameters.AddWithValue("@SALT", Salt);
            cmd.ExecuteNonQuery();
            MessageBox.Show("DATA ADDED");
        }
    }
    catch (OleDbException ex)
    {
        MessageBox.Show(ex.Message);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finally
    {
        c.Close();
    }
