    "ColumnName" ,"ColumnName DESC"
     public static ObjectResult<T> getUsersResStatic<T>(this ObjectContext Entt, string sqlBeginhing, List<string> LstSelectWhersFilter = null, List<string> LstOby = null)
    {
        string SqlCmd = "";
        string StrWhereFilterPrefix = "";
        string StrFinalWHEREFiter ="";
        string StrKeyOb1 = "";
        string StrKeyOb2 = "";
        string StrFinalOrderBy = "";
        if (LstSelectWhersFilter != null)
        {
            StrWhereFilterPrefix = "WHERE";
            for (int CountWhers = 0; CountWhers < LstSelectWhersFilter.Count; CountWhers++)
            {
                if (CountWhers == 0) StrFinalWHEREFiter = string.Format(" {0} {1} ", StrWhereFilterPrefix, LstSelectWhersFilter.ElementAt(CountWhers));
                else
                {
                    StrWhereFilterPrefix = "AND";
                    StrFinalWHEREFiter += string.Format(" {0} {1} ", StrWhereFilterPrefix, LstSelectWhersFilter.ElementAt(CountWhers));
                }
            }
        }
        if (LstOby != null)
        {
            StrKeyOb1 = "ORDER BY";
            if (LstOby.Count > 1)
            {
                StrKeyOb2 = ",";
                for (int i = 0; i < LstOby.Count; i++)
                {
                    if (i == 0) StrFinalOrderBy = string.Format("{0} {1}", StrKeyOb1, LstOby.ElementAt(i));
                    else
                    StrFinalOrderBy += string.Format("{0} {1}", StrKeyOb2, LstOby.ElementAt(i));
                }
            }
            else StrFinalOrderBy = string.Format("{0} {1}", StrKeyOb1, LstOby.ElementAt(0));
            SqlCmd = string.Format("{0} {1} {2}", sqlBeginhing, StrFinalWHEREFiter, StrFinalOrderBy);//StrKeyOb2, ob2);
        }
        if (LstSelectWhersFilter == null && LstOby == null) SqlCmd = sqlBeginhing;
        return Entt.ExecuteStoreQuery<T>(SqlCmd);
    }
