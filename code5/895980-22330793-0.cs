    else
        {
        dateTimePicker1.Value = DateTime.Parse(drA["FDQIS"].ToString());
        StringBuilder sbQuery1 = new StringBuilder();
        SqlCeCommand cmd1k = new SqlCeCommand();
    sbQuery1.Append("UPDATE ACMCT SET FDQIS = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' WHERE NUMIA = '" + NUMIA + "' ... ... "); 
    //////////// NOTE: I USE '' at the beginning and at the end of your date 
    cmd1k.CommandText = sbQuery1.ToString();
    cmd1k.Connection = connd;
    cmd1k.ExecuteNonQuery();
    cmd1k.Dispose();
    }
