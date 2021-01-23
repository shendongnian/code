    internal class TempResult
    {
        public int? EntityId { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
    var tempResults = db.Database.SqlQuery<TempResult>(
        @"SELECT e.entity_id AS EntityId, e.entity_reg_name AS Name,
              a.address_1 AS [RegisteredAddress.Address1]
          FROM
              entity AS e
              LEFT JOIN address AS a ON e.entity_reg_addr_id = a.address_id",
        objectParameterList.ToArray()).ToList();
    
    querySearchResult = tempResults.Select(t => new SearchResult
    {
        EntityId = t.EntityId,
        [...]
        RegisteredAddress = new Address 
            {
                AddressId = t.AddressId,
                [...]
            }
    }
