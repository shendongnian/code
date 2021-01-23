    private void WObutton_Click(object sender, EventArgs e)
    {
        string cmdText = "INSERT INTO TestFC (WOID, WONum, WODesc, WOStatus, ISD) VALUES (?,?,?,?,?)";
        string cnString = @"Provider=Microsoft.ACE.OLEDB.12.0;
         Data Source=C:\Users\Michael\Documents\Visual Studio 2012\Projects\WorkOrderTKv2\WorkOrderTKv2TestAccessdb.mdb";
        using(OleDbConnection conn = new OleDbConnection(cnString))
        using(OleDbCommand cmmd = new OleDbCommand(cmdText, conn))
        {
            conn.Open();
            cmmd.Parameters.AddWithValue("@FirstParam", doubleValue);  // Need a double for field ID
            cmmd.Parameters.AddWithValue("@SeconParam", valueForWO);   // Need a string
            cmmd.Parameters.AddWithValue("@ThirdParam", valueForDESC);   
            cmmd.Parameters.AddWithValue("@FourthParam", valueForStatus);
            cmmd.Parameters.AddWithValue("@FifthParam", valueForISD);   
            try
            {
                cmmd.ExecuteNonQuery();
                MessageBox.Show("DATA ADDED");
                conn.Close();
            }
            catch (OleDbException expe)
            {
                MessageBox.Show(expe.Message);
            }
        }
    }
