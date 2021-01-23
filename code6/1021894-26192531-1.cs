    public class SqlProductRepository : IProductRepository
    {
         private MyDataContext db;
         private Table<Product> _productsTable; 
    
        public IQueryable<Product> Products
        {
            get { return _productsTable; }
        }
        public void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _productsTable.InsertOnSubmit(product);
            }
            else if (_productsTable.GetOriginalEntityState(product) == null)
            {
                _productsTable.Attach(product);
                _productsTable.Context.Refresh(RefreshMode.KeepCurrentValues, product);
            }
            _productsTable.Context.SubmitChanges();
        }
}
