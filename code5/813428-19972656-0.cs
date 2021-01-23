    try
    {
        conn.Open();
        SqlCeCommand cmd = new SqlCeCommand(ParameterisedSQlQueryText, conn);
        //Put your parameters in here
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex) {MessageBox.Show(ex.Message);}
    finally {conn.Close();}
