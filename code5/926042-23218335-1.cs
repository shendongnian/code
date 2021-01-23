    param = new SqlParameter("@LicenseDate", SqlDbType.DateTime);
     if (SearchCriteria.LicenseDate != null && SearchCriteria.LicenseDate != default(DateTime))
      {
       param.Value = SearchCriteria.LicenseDate;
      }
     else
      {
       param.Value = new DateTime(1900,1,1,0,0,0)
       }
    cmd.Parameters.Add(param);
