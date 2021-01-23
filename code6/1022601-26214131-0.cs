    namespace ContextNamespace
    {
        public partial class ContextClass
        {
          public Task UpdateShipments(List<Tuple<tblShipment,
                                            List<tblActivity>>> shipments)
          {
            return this.Database.ExecuteSqlCommandAsync("EXEC spSavePackage @p1 = @p1..", 
                   new SqlParameter("@p1", shipments.???),....);
           }
        }
    }
