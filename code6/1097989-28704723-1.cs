    SqlConnection con = new SqlConnection(Settings.Default.FrakoConnectionString);
    SqlCommand maxcommand = new SqlCommand("SELECT MAX(Counter) AS max FROM ppartikulieren", con);
    try
    {
        con.Open();
        max = (int)maxcommand.ExecuteScalar() + 1;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Fout bij het plakken:\n" + ex.Message, "Frako planner", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
    finally
    {
        con.Close();
    }
