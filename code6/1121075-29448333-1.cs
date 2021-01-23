        try
        {
            using (DataAccess.ExecuteDataTable("[dbo].[udp_Customers_ups]",
                DataAccess.Parameter(CustomerIdColumn, CustomerId),
                DataAccess.Parameter(CodeColumn, Code),
                DataAccess.Parameter(CompanyColumn, Company),
                DataAccess.Parameter(IsDeletedColumn, IsDeleted),
                DataAccess.Parameter(LastUpdatedColumn, LastUpdated),
                DataAccess.Parameter(UpdatedByColumn, UpdatedBy)))
                return true;
        }
        catch
        {
            return false;
        }
