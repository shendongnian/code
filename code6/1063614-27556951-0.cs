    public JsonResult returnAllHumans()
    {
        TestService.TestServiceSoapClient soapClient = new TestService.TestServiceSoapClient();
        object[] humansfromWS = soapClient.GetAllHumans();
    
        System.Data.DataTable table = new System.Data.DataTable();
        table.Columns.Add("FirstName", typeof(string));
        table.Columns.Add("LastName", typeof(string));
        table.Columns.Add("Gender", typeof(string));
        table.Columns.Add("Age", typeof(int));
        
        
        for (int i = 0; i < humansfromWS.Length; i++){
            var humanFromWS = humansfromWS[i];
            table.Rows.Add(new object[] {
                        humansFromWS.FirstName,
                        humansFromWS.LastName,
                        humansFromWS.Gender,
                        humanFromWS.Age});
        }
