    param = new SqlParameter("@CodeNumber", SqlDbType.VarChar);
     if (!string.IsNullOrEmpty(SearchCriteria.CodeNumber))
      {
       param.Value = SearchCriteria.CodeNumber;
      } 
     else
      {
       param.Value = String.Empty;    
      }
    cmd.Parameters.Add(param);
