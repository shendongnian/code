     String StrSQL = "INSERT INTO tblLog ([Part_Number],[Quantity],[Date],[LOC_Warehouse],[LOC_Row],[LOC_Section],[LOC_Level],[LOC_Bin],[Stock_Added],[Stock_Removed],[Quarantine_Set],[Quarantine_Removed])"
                    + "VALUES(@Part_Number, @Quantity, @Date, @Warehouse, @Row, @Section, @Level, @Bin, @Stock_Added, @Stock_Removed, @Quarantine_Set, @Quarantine_Removed)";
    SqlConnection conn = new SqlConnection(WHITS.Properties.Settings.Default.LocalConnStr);
    SqlCommand cmd = new SqlCommand(StrSQL, conn);
    cmd.Parameters.AddWithValue("@Part_Number", Part_Number);
    cmd.Parameters.AddWithValue("@Quantity", Quantity);
    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
    //More Parameters... Skipped for brevity.
    conn.Open();
    cmd.ExecuteNonQuery();
    conn.Close();
