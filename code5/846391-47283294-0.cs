    public IList<Models.StandardRecipeDetail> GetRequisitionDetailBySearchCriteria(Guid subGroupItemId, Guid groupItemId)
            {
                var query = this.UnitOfWork.Context.Database.SqlQuery<Models.StandardRecipeDetail>("SP_GetRequisitionDetailBySearchCriteria @SubGroupItemId,@GroupItemId",
                new System.Data.SqlClient.SqlParameter("@SubGroupItemId", subGroupItemId),
                new System.Data.SqlClient.SqlParameter("@GroupItemId", groupItemId));
    
               
                    return query.ToList();
               
            }
