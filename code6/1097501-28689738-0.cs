    public static int writePatient(DataSetTrial dataSetTrial, int ethnicityID, int genderID, int raceID, DateTime dob, DateTime dateOfConsent, int hhpid)
    {
        int addedRow;
        //OleDbDataAdapter writePatientAdapter; don't need this
        try
        {
        //configure adapter
        //writePatientAdapter = new OleDbDataAdapter(); no, you don't need it
        //insert command
        var InsertCommand = new OleDbCommand();
        InsertCommand.CommandText = "INSERT INTO Patient (EthnicityID,GenderID,RaceID,DateOfBirth, " +
                                                                    " DateOfConsent,HomeHealthPatientID) " +
                                                                    " VALUES (?,?,?,?,?,?)";
                                                                                    
        InsertCommand.Connection = new     OleDbConnection(connectString);
              
         //insert command paramaters
        InsertCommand.Parameters.Add("@EthnicityID", OleDbType.Integer);
         writePatientAdapter.InsertCommand.Parameters["@EthnicityID"].Value = ethnicityID; 
                
        InsertCommand.Parameters.Add("@GenderID", OleDbType.Integer);
         writePatientAdapter.InsertCommand.Parameters["@GenderID"].Value = genderID; 
        InsertCommand.Parameters.Add("@RaceID", OleDbType.Integer);
         writePatientAdapter.InsertCommand.Parameters["@RaceID"].Value = raceID;
        InsertCommand.Parameters.Add("@DateOfBirth", OleDbType.Date);
         writePatientAdapter.InsertCommand.Parameters["@DateOfBirth"].Value = dob; 
        InsertCommand.Parameters.Add("@DateOfConsent", OleDbType.Date);
         writePatientAdapter.InsertCommand.Parameters["@DateOfConsent"].Value = dateOfConsent; 
        InsertCommand.Parameters.Add("@HomeHealthPatientID", OleDbType.Integer);
         
        InsertCommand.Parameters["@HomeHealthPatientID"].Value = hhpid; 
     
        InsertCommand.Connection.Open();
        addedRow = InsertCommand.executeNonQuery();
         }
         catch (Exception)
         {
             throw new ApplicationException(dbOrDeErrorMsg);
         }
             InsertCommand.Connection.Close();
             return addedRow;
    }
