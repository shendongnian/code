    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Resource Resource { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0} Name: {1} Resource: {2}", BuildingId, BuildingName, Resource);
        }
    }
    
    public class Resource
    {
        public int Wood { get; set; }
        public int Food { get; set; }
        public int Stone { get; set; }
        public int Gold { get; set; }
        public override string ToString()
        {
            return string.Format("Wood: {0} Food: {1} Stone {2} Gold {3}", Wood, Food, Stone, Gold);
        }
    }
    var sql = @"SELECT 1 AS BuildingId, 'tower' AS BuildingName, 1 AS Wood, 1 AS Food, 1 AS Stone, 1 AS Gold
                UNION ALL
                SELECT 2 AS BuildingId, 'shed' AS BuildingName, 1 AS Wood, 1 AS Food, 1 AS Stone, 1 AS Gold";
    
    var buildings = new List<Building>();
    using(var connection = GetOpenConnection())
    {
        using(var reader = connection.QueryMultiple(sql))
        {
            var building = reader.Read<Building, Resource, Building>(
                (b, r) => { b.Resource = r; return b; }, splitOn: "Wood");
            buildings.AddRange(building);
        }
    }
    foreach(var building in buildings)
    {
        Console.WriteLine(building);
    }
