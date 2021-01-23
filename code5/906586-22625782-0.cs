    public IList<ShowInstitutes> ShowInstitutes(int instituteId)
    {
       var d = SqlHelper.ExecuteDataset(dBConnection, "usp_SPName");
    
       var myData = d.Tables[0].AsEnumerable().Select(r => new ShowInstitutes{
       InstituteName = r.Field<string>("InstituteName "),
       InstituteCity = r.Field<string >("InstituteCity "),
       InstituteId = r.Field<int>("InstituteId ")
       });
       var list = myData.ToList();
       return list;
    }
