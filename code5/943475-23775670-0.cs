    IDataReader rdr = Syntegra.Manufacturing.WMCCM.Companies.Companies.ListCompanies(dgCompanies.CurrentPageIndex, pageSize, CompanyList, CompanyNameStartsWith, ProcessSqlClause, SkillSqlClause, LocationClause, KeywordSqlClause, User, Status, SearchPortalId, false, sortColumn, sortDirection);
    DataTable dt = new DataTable();
    dt.Load(rdr);
    //select rows based on criteria
    DataRow[] dataRows = dt.Select("companyCount = 5");
    //remove rows from datatable
    
    dt.AcceptChanges();
    dgCompanies.PageSize = pageSize;
    dgCompanies.DataSource = dt;  //provide datatable as datasource
    dgCompanies.DataBind();
