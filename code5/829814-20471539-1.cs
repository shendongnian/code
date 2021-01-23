    private void MainForm_Load(object sender, EventArgs e)
    {
    	gridControl.DataSource = Product.GetProducts();
    }
    
    private void gridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
    {
    	var product = gridView.GetFocusedRow() as Product;
    	if (product == null)
    		return;
    
    	// Calculating the dicsount %
    	if (e.Column == colDiscountAmount)
    	{
    		product.DiscountPercent = (product.DiscountAmount*100)/product.Price;
    	}
    
    	// Calculating the discount amout
    	if (e.Column == colDiscountPercent)
    	{
    		product.DiscountAmount = product.Price*(product.DiscountPercent/100);
    	}
    }
