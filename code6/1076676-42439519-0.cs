        IQueryable<Cm_Customer> customerQuery = _uow.SqlQuery<Cm_Customer>(@" DECLARE @UserId INT = {0}
                                                   EXEC Cm_GetCustomersByUserId @UserId", filter.UserId).AsQueryable();
        IQueryable<Cm_Customer> custs = customerQuery.IncludeMultiple(k => k.Cm_CustomerLocations,
                                               k => k.Cm_CustomerSalesmans,
                                               k => k.Cm_CustomerMachineparks,
                                               k => k.Cm_CustomerAuthenticators,
                                               k => k.Cm_CustomerInterviews,
                                               k => k.Cm_CustomerRequest,
                                               k => k.Cm_MachineparkRental).AsQueryable();
