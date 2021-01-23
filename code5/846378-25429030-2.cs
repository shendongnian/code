        using(var context = new DatabaseContext())
        {
                var clientIdParameter = new SqlParameter("@ClientId", 4);
                var result = context.Database
                    .SqlQuery<ResultForCampaign>("GetResultsForCampaign @ClientId", clientIdParameter)
                    .ToList();
        }
