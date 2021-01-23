        public bool Save()
        {
            using (DataAccess.ExecuteDataTable("[dbo].[udp_Customers_ups]",
                DataAccess.Parameter(CustomerIdColumn, CustomerId),
                DataAccess.Parameter(CodeColumn, Code),
                DataAccess.Parameter(CompanyColumn, Company),
                DataAccess.Parameter(CommentsColumn, Comments),
                DataAccess.Parameter(ContactColumn, Contact),
                DataAccess.Parameter(StreetColumn, Street),
                DataAccess.Parameter(CityColumn, City),
                DataAccess.Parameter(StateColumn, State),
                DataAccess.Parameter(ZipcodeColumn, Zipcode),
                DataAccess.Parameter(PhoneColumn, Phone),
                DataAccess.Parameter(IsNewColumn, IsNew),
                DataAccess.Parameter(IsDeletedColumn, IsDeleted),
                DataAccess.Parameter(LastUpdatedColumn, LastUpdated),
                DataAccess.Parameter(UpdatedByColumn, UpdatedBy)))
            {
                return true;
            }      
        } 
