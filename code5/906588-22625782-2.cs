    public IList<ShowInstitutes> ShowInstitutes(int instituteId)
    {
       var d = SqlHelper.ExecuteDataset(dBConnection, "usp_SPName");
    
       var myData = d.Tables[0].AsEnumerable().Select(data => new ShowInstitutes{
           InstituteName = data.Field<string>("InstituteName "),
           InstituteCity = data.Field<string >("InstituteCity "),
           InstituteId = data.Field<int>("InstituteId ")
       });
       var list = myData.ToList();
       return list;
    }
