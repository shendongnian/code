    IDataReader rdr = Syntegra.Manufacturing.WMCCM.Companies.Companies.
                      ListCompanies(dgCompanies.CurrentPageIndex, pageSize, CompanyList,
                      CompanyNameStartsWith, ProcessSqlClause, SkillSqlClause, 
                      LocationClause, KeywordSqlClause, User, Status, SearchPortalId, false, 
                      sortColumn, sortDirection);
    DataTable dt = new DataTable();
    dt.(rdr);
    //For filtering all the CompanyID column value not equal to  5
    DataRow[] filteredRows=DataTable.Select("[CompanyID] <> 5 " ); 
    dgCompanies.PageSize = pageSize;
    dgCompanies.DataSource = filteredRows;
    dgCompanies.DataBind();
