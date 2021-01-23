    var query = MyEntityDBO.CreateQuery<DynamicTableEntity>()
                .Where(x => x.PartitionKey.Equals("Blah"))
                .Resolve(MyEntityDTO.GetEntityResolver());
    var segment = await query.ExecuteSegmentedAsync(new TableContinuationToken());
    if(segment.Results.Count > 0) {
         // Results = IEnumerable<MyEntityDTO>
    }
    public class MyEntityDTO
    {
        public string Id { get; set; }
        public string Mode { get; set;  }
        public string Env { get; set; }
        public string Ver { get; set; }
        public static EntityResolver<MyEntityDTO> GetEntityResolver()
        {
            return (pk, rk, ts, props, etag) =>
            { 
                 Env = pk,
                 Ver = rk,
                 Id = props["Id"].StringValue,
                 Mode = props["Mode"].StringValue
            };
        }
    }
    
