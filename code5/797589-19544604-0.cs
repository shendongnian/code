    Guid patientID = userSession.UserIDNative;
    if(userSession.IsAdmin.ToUpper() == "TRUE")
    {
        patientID = new Guid("3aac8d07-ad35-e311-8bdf-9ebf7757768f");
    }
    else
    {
        patientID = userSession.UserIDNative;
    }
    
    System.Data.DataSet ds = MeasuredHealthBeta1.Utilities.DataHelper.Measurements_Get306060DayGlucoseMeasurements(patientID); 
