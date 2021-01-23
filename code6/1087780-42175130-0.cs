    public IList<Models.SalesTargetDetail> getSalesTarget(int SpId){
        System.Text.StringBuilder sbSql = new System.Text.StringBuilder();
        sbSql.Append(@"select Cast(STD.Qty as varchar(10)) as Qty from tblSalesTarget ST inner join tblSalesTargetDetail STD on ST.Id=STD.SalesTargetId where 1=1");
        sbSql.Append(" and STD.SalesTargetId=" + SpId);
        var data = this.UnitOfWork.Context.Database.SqlQuery<Models.SalesTargetDetail>(sbSql.ToString()).ToList<Models.SalesTargetDetail>();
        return data.ToList<Models.SalesTargetDetail>();
    }
