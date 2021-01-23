            public IQueryable<Company> FullTextSearchCompaniesByName(int limit, int offset, string input, Guid accountingBureauId, string orderByColumn)
        {
            FtsQueryBuilder ftsQueryBuilder = new FtsQueryBuilder();
            ftsQueryBuilder.Input = FtsQueryBuilder.FormatQuery(input);
            ftsQueryBuilder.TableName = FtsQueryBuilder.GetTableName<Company>();
            ftsQueryBuilder.OrderByTable = ftsQueryBuilder.TableName;
            ftsQueryBuilder.OrderByColumn = orderByColumn;
            ftsQueryBuilder.Columns.Add("CompanyId");
            if (accountingBureauId != null && accountingBureauId != Guid.Empty)
                ftsQueryBuilder.AddConditionQuery<Guid>(Condition.And, "" , @"dbo.""Company"".""AccountingBureauId""", Operator.Equals, accountingBureauId, "AccountingBureauId", "");
            ftsQueryBuilder.AddConditionQuery<bool>(Condition.And, "", @"dbo.""Company"".""Deleted""", Operator.Equals, false, "Deleted", "");
            var companiesQuery = ftsQueryBuilder.BuildAndExecuteFtsQuery<Guid>(Context, limit, offset, "Name");
            TotalCountQuery = ftsQueryBuilder.Total;
            HashSet<Guid> companiesIdSet = new HashSet<Guid>(companiesQuery);
            var q = Query().Where(a => companiesIdSet.Contains(a.CompanyId));
            return q;
        }
