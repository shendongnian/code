    //the index
    public class FlattenIndex: AbstractIndexCreationTask<PortalEntry>
        {
            public class ReduceResult
            {
                public string Key { get; set; }
                public string Value { get; set; }
            }
            public FlattenIndex()
            {
                Map = portalEntries => from portalEntry in portalEntries                                                               
                                       from p in portalEntry.MetadataProperties.Concat(portalEntry.NamedProperties)
                               select new
                               {
                                   Key=p.Key,
                                   Value=p.Value
                               };
            }
        }
    //the query
     using (var session = _docStore.OpenSession())
                {
                    var someEntries = session.Query<FlattenIndex.ReduceResult, FlattenIndex>()
                        .Where(x => x.Key == "Language" && x.Value == "English")
                        .As<PortalEntry>()
                        .ToArray();
                    if (someEntries!=null)
                        foreach(var entry in someEntries )
                        {
                            Console.WriteLine(entry.Id);
                        }
                }
