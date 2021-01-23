     public IQueryable<Product> BindProduct([Control("ddProductName")] int? ProductNameId)
        {
            var prodName = ddProductName.SelectedItem.Text;
            var prod = _DbContext.Products.Where(c => c.ProductNameId == ProductNameId).ToList().Select
                (p =>
                {
                    p.Name = string.IsNullOrEmpty(p.Name) ? prodName : p.Name;
                    return p;
                }).OrderBy(p => p.Name).ThenBy(p => p.ItemNumber).AsQueryable();
            return prod;
        }
