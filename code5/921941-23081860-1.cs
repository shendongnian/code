        protected void cmdSave_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\IFMComac\\Documents\\Visual Studio 2013\\ifm.mdb.accdb";
    
            string cmdString = ("INSERT INTO tblCheck (ChecklistID, Vehicle, Driver, WeekEnding, FuelLevel, WindscreenWasher, SteeringWheel,Brakes, Clutch, Horn, Heater, SeatBelts, WarningLights, Mirrors, Tires/Wheels, Exhaust, Lights/Reflectors, ExteriorLeaks, Body, OilLevel, CoolantLevel, Belts, EngineLeaks, LooseBolts/Screws, WarningTriangle, FireExtinguishers/FirstAidKit, AdditionalComments, CFirstName, CLastName)" + " Values (@CheckID, @Vehicle, @Driver, @WeekEnding, @FuelLevel, @WindscreenWasher, @SteeringWheel, @Brakes, @Clutch, @Horn, @Heater, @SeatBelts, @WarningLights, @Mirrors, @Tires/Wheels, @Exhaust, @Lights/Reflectors, @ExteriorLights, @Body, @OilLevel, @CoolantLevel, @Belts, @EngineLeaks, @LooseBolts/Screws, @WarningTriangle, @FireExtinguishers/FirstAidKit, @AdditionalComments, @CFirstName, @CLastName)");
            OleDbCommand cmd = new OleDbCommand(cmdString, conn);
    
            if (conn.State == ConnectionState.Closed)
            {
                 conn.Open();
            }
            
    
    cmd.Parameters.Add("@CheckID", OleDbType.Integer, 5).Value = txtID;
            cmd.Parameters.Add(@"Vehicle", OleDbType.VarChar, 10).Value = ddlReg;
            cmd.Parameters.Add(@"Driver", OleDbType.VarChar, 30).Value = ddlReg;
            cmd.Parameters.Add(@"WeekEnding", OleDbType.Date, 40).Value = cldDate0;
            cmd.Parameters.Add(@"FuelLevel", OleDbType.Boolean, 40).Value = chkbxSelect1;
            cmd.Parameters.Add(@"WindscreenWasher", OleDbType.Boolean, 40).Value = chkbxSelect6;
            cmd.Parameters.Add(@"SteeringWheel", OleDbType.Boolean, 40).Value = chkbxSelect11;
            cmd.Parameters.Add(@"Brakes", OleDbType.Boolean, 40).Value = chkbxSelect16;
            cmd.Parameters.Add(@"Clutch", OleDbType.Boolean, 40).Value = chkbxSelect21;
            cmd.Parameters.Add(@"Horn", OleDbType.Boolean, 40).Value = chkbxSelect26;
            cmd.Parameters.Add(@"Heater", OleDbType.Boolean, 40).Value = chkbxSelect31;
            cmd.Parameters.Add(@"SeatBelts" , OleDbType.Boolean, 40).Value = chkbxSelect36;
            cmd.Parameters.Add(@"WarningLights" , OleDbType.Boolean, 40).Value = chkbxSelect41;
            cmd.Parameters.Add(@"Mirrors", OleDbType.Boolean, 40).Value = chkbxSelect46;
            cmd.Parameters.Add(@"Tires/Wheels", OleDbType.Boolean, 40).Value = chkbxSelect51;
            cmd.Parameters.Add(@"Exhaust", OleDbType.Boolean, 40).Value = chkbxSelect56;
            cmd.Parameters.Add(@"Lights/Reflectors", OleDbType.Boolean, 40).Value = chkbxSelect61;
            cmd.Parameters.Add(@"Exterior Leaks", OleDbType.Boolean, 40).Value = chkbxSelect66;
            cmd.Parameters.Add(@"Body", OleDbType.Boolean, 40).Value = chkbxSelect71;
            cmd.Parameters.Add(@"OilLevel", OleDbType.Boolean, 40).Value = chkbxSelect76;
            cmd.Parameters.Add(@"CoolantLevel", OleDbType.Boolean, 40).Value = chkbxSelect81;
            cmd.Parameters.Add(@"Belts", OleDbType.Boolean, 40).Value = chkbxSelect86;
            cmd.Parameters.Add(@"EngineLeaks", OleDbType.Boolean, 40).Value = chkbxSelect91;
            cmd.Parameters.Add(@"LooseBolts/Screws", OleDbType.Boolean, 40).Value = chkbxSelect96;
            cmd.Parameters.Add(@"WarningTriangle", OleDbType.Boolean, 40).Value = chkbxSelect101;
            cmd.Parameters.Add(@"FireExtinguisher/FirstAidKit", OleDbType.Boolean, 40).Value = chkbxSelect106;
            cmd.Parameters.Add(@"AdditionalComments", OleDbType.VarChar, 100).Value = addCom;
            cmd.Parameters.Add(@"CFirstName", OleDbType.VarChar, 30).Value = txtFirstName;
            cmd.Parameters.Add(@"CLastName", OleDbType.VarChar, 30).Value = txtLastName;
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
