    public partial class StatCentricEntities
    {
        public virtual List<sp_Log_PageView2_Result> my_sp_Log_PageView2(
            Guid? siteId, 
            DateTime time, 
            string param3, 
            string param4 )
        {
            return Database.SqlQuery<sp_Log_PageView2_Result>(
                   "sp_Log_PageView2 @siteId @time @param3 @param4",
                    new SqlParameter("siteId", siteId),
                    new SqlParameter("time", time),
                    new SqlParameter("param3", param3),
                    new SqlParameter("param4", param4)).ToList();
        }
    }
