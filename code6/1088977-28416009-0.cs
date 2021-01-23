    public IQueryable<SocialRecord> GetWallSocialRecordsMongoQuery(Dictionary<string, List<string>> languagesPerTerms, string[] sources, DateTime fr, DateTime to)
            {
                try
                {
                    var list = new BindingList<IMongoQuery>();
    
                    foreach (var languagesPerTerm in languagesPerTerms)
                    {
                        var term = languagesPerTerm;
                        list.Add(!term.Value.Contains("All")
                                     ? Query.And(
                                         Query<SocialRecord>.Where(record => record.TermMonitorIds.Contains(term.Key)),
                                         Query<SocialRecord>.In(record => record.Language, term.Value))
                                     : Query<SocialRecord>.Where(record => record.TermMonitorIds.Contains(term.Key)));
                    }
    
                    var query = Query.And(Query<SocialRecord>.GTE(record => record.DateCreated, fr),
                                  Query<SocialRecord>.LTE(record => record.DateCreated, to),
                                  Query<SocialRecord>.In(record => record.SocialType, sources),
                                  Query.Or(list));
    
                    //var x = _collection.FindAs<SocialRecord>(query).Explain();
    
                    return _collection.FindAs<SocialRecord>(query).AsQueryable();
                }
                catch (Exception ex)
                {
                    Log.Error("Exception in the Method GetWallSocialRecords, in the Class MongoSocialRecordRepository", ex);
                }
    
                return null;
            }
