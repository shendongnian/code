    private DataTable _products;
    public void ClassName()
    {
        _products = new DataTable
        {
            Columns = { { "Product", typeof(string) }, { "Lot", typeof(string) }, { "Qty", typeof(int) } }
        };
        _products.PrimaryKey = new[] { _products.Columns[0] };
    }
