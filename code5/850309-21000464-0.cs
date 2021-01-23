    public class SaleGroupBuilder : AbstractAuditBuilder
    {
        private readonly SaleGroup saleGroup = new SaleGroup();
        public SaleGroupBuilder() : base(saleGroup)
        {
            saleGroup.SaleGroupId = 1;
            saleGroup.Description = "Miscellaneous";
        }
    //...
