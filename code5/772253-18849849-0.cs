    var buildings = new List<Building.Building>();
    
    using (IDbConnection connection = OpenConnection())
    {
        using(var reader = connection.QueryMultiple("UserBuildingGet",
                                                    new { UserId = UserId },
                                                    commandType: CommandType.StoredProcedure))
        {
            var building = reader.Read<Building.Building,
                                       Resource.Resource,
                                       Building.Building>
                ((b, r) => b.Resource = r, splitOn: "Wood");
            buildings.Add(building);
        }
    }
    
    return buildings;
