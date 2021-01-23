    var session = GetCurrentSession();
    var query = session.CreateSQLQuery("exec SPName @param1=:param1,   @param2=:param2");
    query.SetParameter("param1", value1);
    query.SetParameter("param2", value2);
    var multiResults = session.CreateMultiQuery()
	    .Add(query)// More table your procedure returns,more empty SQL query you should add
	    .Add(session.CreateSQLQuery(" "))
	    .Add(session.CreateSQLQuery(" "))
	    .Add(session.CreateSQLQuery(" "))
	    .Add(session.CreateSQLQuery(" ")
	    .AddScalar("export_file_line", NHibernateUtil.String))// the fifth result set
	    .Add(session.CreateSQLQuery(" "))
	    .Add(session.CreateSQLQuery(" ")
	    .AddScalar("export_file_line", NHibernateUtil.String))// the seventh result set
	    .Add(session.CreateSQLQuery(" "))
	    .List();
    if (multiResults == null || multiResults.Count <= 6 || multiResults[4] == null || multiResults[6] == null) return result;
    var headerList = (System.Collections.IList)multiResults[4];
    var detailsList = (System.Collections.IList)multiResults[6];
