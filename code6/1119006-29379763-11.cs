    [Inject] //using Ninject to inject MsSqlStoreRepository 
    public IStoreRepository Repo { get; set; }
    protected void AddProductBtn_Click(object sender, EventArgs e)
    {
	    Product product = new Product()
		{
		    Id = Int32.Parse(IdTB.Text),
			Name = NameTB.Text,
			Description = DescriptionTB.Text,
			Price = Double.Parse(PriceTB.Text)
		};
		Repo.AddNewProduct(product);
        //now clear the form or show success message etc
	}
