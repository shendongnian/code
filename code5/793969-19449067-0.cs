	public class Product
	{
		public virtual int ProductId { get; set; }
		public virtual string Name { get; set; }
	}
	public class ProductEx : Product, ISomeInterface
	{
		private readonly Product _product;
		public ProductEx(Product product) {
			this._product = product;
		}
		public bool ISomeInterface.SomeMethod() { return false; }
		
		public override int ProductId
		{ 
			get { return this._product.ProductId; }
			set { this._product.ProductId = value; }
		}
		
		public override string Name
		{ 
			get { return this._product.Name; }
			set { this._product.Name = value; }
		}
	}
