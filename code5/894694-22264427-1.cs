    public static List<ClaimService> GetServicesForAccountType(DatabaseContainer db,Guid claimId, Guid accountTypeId)
    {
        DatabaseContaner localScopeDbContainer = null;
        try
        {
            return (db ?? (localScopeDbContainer = new DatabaseContainer()).Database.SqlQuery<ClaimService>("SELECT * FROM dbo.ClaimService WHERE ClaimId = '@p1' AND AccountTypeId = '@p2'", new System.Data.SqlClient.SqlParameter("p1", claimId), new System.Data.SqlClient.SqlParameter("p2", accountTypeId)).ToList();
        }
        finally
        {
            if (localScopeDbContainer != null)
                localScopeDbContainer.Dispose();
        }
    }
