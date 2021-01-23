    IDataReader rdr = Syntegra.Manufacturing.WMCCM.Companies.Companies.ListCompanies(dgCompanies.CurrentPageIndex, pageSize, CompanyList, CompanyNameStartsWith, ProcessSqlClause, SkillSqlClause, LocationClause, KeywordSqlClause, User, Status, SearchPortalId, false, sortColumn, sortDirection);
    DataTable dt = new DataTable();
    dt.Load(rdr);
    rdr.Close();
    for(int i = dt.Rows.Count-1; i >= 0; i--)
    {
       DataRow dr = dt.Rows[i];
    
       int iCompanyId = Convert.ToInt(dr["CompanyId"]);
    
       if (IsCompanyHavingChoiceYes(iCompanyId))
        dr.Delete();
    }   
   
    
    dt.AcceptChanges();
    dgCompanies.PageSize = pageSize;
    dgCompanies.DataSource = dt;  //provide datatable as datasource
    dgCompanies.DataBind();
