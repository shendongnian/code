    // option 1
    private static void EndOwnershipForTeam(long assetId, int teamId)
    {
        const string storedProcedureName = @"up_RemoveAssetOwnershipFromTeam";
        using (var connection = new SqlConnection("context connection=true"))
        using (var command = new SqlCommand(storedProcedureName, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("assetId", assetId);
            command.Parameters.AddWithValue("teamId", teamId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    // option 2
    private static void EndOwnershipForTeam(long assetId, int teamId)
    {
        const string sql = @"exec up_RemoveAssetOwnershipFromTeam @assetId, @teamId";
        using (var connection = new SqlConnection("context connection=true"))
        using (var command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@assetId", assetId);
            command.Parameters.AddWithValue("@teamId", teamId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
