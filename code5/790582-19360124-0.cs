            public IEnumerable<string> Retrieve()
            {
                return _databaseConnection.tblAccounts.Select(account => account.UserId).Distinct();
            }
    
            public IEnumerable<string> GetMatchingItems(IEnumerable<string> salesAgents)
            {
                var regex = new Regex(@"(?<=\\)(.*?)(?=\:)");
    
                return (from agent in salesAgents
                        .AsEnumerable()
                        select regex.Match(agent)
                            into match
                            where match.Success
                            select match.Value.ToUpper())
                        .OrderBy(match => match);
            }
       
