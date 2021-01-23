    int anInteger;
    anInteger = Convert.ToInt32(textBox9.Text);
    anInteger = int.Parse(textBox9.Text);
    
    sql = "SELECT * FROM [Consultant Doctor] " + 
           "INNER JOIN Patients ON [Consultant Doctor].DoctorID = Patients.DoctorID " +
           "WHERE Patients.PatientID = @pID";
    sConnection =  "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hospital database.accdb";
    using(OleDbConnection dbConn = new OleDbConnection(sConnection))
    using(OleDbCommand dbCmd = new OleDbCommand(sql dbConn))
    {
        dbConn.Open();
        dbCmd.Parameters.AddWithValue("pID", anInteger);
        using(OleDbDataReader dbReader = dbCmd.ExecuteReader())
        {
            if(dbReader.Read())
            {
                 listBox3.Items.Add(dbReader["PatientID"]);
                 listBox3.Items.Add(dbReader["DoctorName"]);
                 listBox3.Items.Add(dbReader["DoctorAddress"]);
                 listBox3.Items.Add(dbReader["Specialization"]);
                 listBox3.Items.Add(dbReader["WardID"]);
                 listBox3.Items.Add(dbReader["TeamID"]);
            }
        }
     }
