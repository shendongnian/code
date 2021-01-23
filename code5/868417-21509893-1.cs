    cmd.Parameters.Add("@nric", SqlDbType.NVarChar, 100);
    if (string.IsNullOrEmpty((string)Session["CustomerNRIC"]))
    {
        cmd.Parameters["@nric"].Value = DBNull.Value;
    }
    else
    {
        cmd.Parameters["@nric"].Value = Session["CustomerNRIC"];
    }
