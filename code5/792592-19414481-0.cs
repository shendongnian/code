	public class ProductMap : ClassMap<ProductModel>
	{
		public ProductMap()
		{
			Table("Product");
			Id(x => x.Id);
			Map(x => x.ProductName);
			HasMany<LicenseModel>(x => x.License)
				.Inverse()
				.KeyColumn("ProductModelId");
		}
	}
	public class LicenseMap : ClassMap<LicenseModel>
	{
		public LicenseMap()
		{
			Table("License");
			Id(x => x.Id);
			Map(x => x.Period);
			Map(x => x.Price);
			Map(x => x.Discount);
			References<ProductModel>(x => x.ProductModel)
				.Column("ProductModelId");
		}
	}
