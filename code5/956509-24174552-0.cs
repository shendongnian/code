    try
    {
        objConn.Open();
        using (var updateCmd = new SqlCommand(objConn))
        {
            updateCmd.CommandText =
                "update EXPORT set MODE_PAI=@modeP ,MNT_REG=@mantantR where NUM_FAC=@Itemchek";
            updateCmd.Parameters.Add("@modeP", modeP);
            updateCmd.Parameters.Add("@mantantR", mantantR);
            updateCmd.Parameters.Add("@Itemchek", Itemchek);
            da.UpdateCommand = updateCmd;
            da.Update(ds, "EXP");
        }
    }
    catch (Exception x)
    {
        MessageBox.Show(x.ToString());
    }
    finally
    {
        objConn.Close();
    }
