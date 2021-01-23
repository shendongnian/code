           using (var service =  new  OrganizationService(CrmConnection.Parse("CRMConnectionString")))
        {
    var Res = service.Retrieve("sv_answer", new Guid("GUID Of Record"), new ColumnSet("ColumnName "));
        }
 
 
  
