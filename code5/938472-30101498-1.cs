    SqlCeConnection con = new SqlCeConnection("Data Source=K:/PROJECT LOCATION/Database1.sdf");
    con.Open();           
    string x = "insert into TABLE(your columns) values (what values you want)";
    SqlCeCommand cmd = new SqlCeCommand(x, con);
    try
    {
        cmd.ExecuteNonQuery();
    }
    catch
    {
        MessageBox.Show(" Something is wrong","ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    con.Close();
