    public void TestMethod()
    {
        DataSet lDataSet = new DataSet();
        var lOutput = (from lRosterSummaryBand in lDataSet.Tables[0].AsEnumerable()
                       select new RosterSummaryData_Subject_Local 
                       {
                           //Assign the field value for each row to the model property specified.
                           //Make sure to use the correct data types specified from the data base.
                           pkSummarySubjectLocalID = lRosterSummaryBand.Field<System.Int64>("pkSummarySubjectLocalID") // Column name from DataTable / DataSet
                       }).ToList();//Make sure to set the output as an enumeration
    }
