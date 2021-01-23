    public class ItemSaleDetail
    {
        string _itemSaleCode;
        public virtual string ItemSaleCode
        {
            get { return _itemSaleCode ?? SaleParent.SaleCode ; }
            set { _itemSaleCode  = value; }
        }
