    private void button1_Click(object sender, EventArgs e)
    {
        this.Process1();
    }
    // public is important
    public void Process1()
    {
        MySqlConnection conn = new MySqlConnection("Data source = 15.25.12.08; database = test;uid=rrr ;pwd=fsssss ;Convert Zero Datetime=true;");
        DataTable db = new DataTable();
        string strLoadData = "LOAD DATA LOCAL  INFILE 'F:/Explor/final test/finaltest12.csv' INTO TABLE tickets  FIELDS  terminated by ',' ENCLOSED BY '\"'  lines terminated by '\n' IGNORE 1 LINES (SiteId,DateTime,Serial,DeviceId,AgentAID,VehicleRegistration,CarPark,SpaceNumber,GpsAddress,VehicleType,VehicleMake,VehicleModel,VehicleColour,IssueReasonCode,IssueReason,NoticeLocation,Points,Notes)";
        MySqlCommand cmd1 = new MySqlCommand(strLoadData, conn);
        cmd1.CommandTimeout = 6000;
        cmd1.Connection = conn;
        conn.Open();
        cmd1.Prepare();
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
