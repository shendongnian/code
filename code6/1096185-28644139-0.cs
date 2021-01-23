	// in UserAddedItemToCart.cs
	public class UserAddedItemToCart
	{
		public UserAddedItemToCart(int productId)
		{
			this.ProductId = productId;
		}
		
		public readonly int ProductId;	
	}
	// in UserRemovedItemFromCart.cs
	public class UserRemovedItemFromCart
	{
		public UserAddedItemToCart(int productId)
		{
			this.ProductId = productId;
		}
		
		public readonly int ProductId;
	}
	
	// in Cart.cs
    public class Cart : AggregateBase
    {
		private readonly HashSet<int> Items = new HashSet<int>();
		
		public void AddItem(int itemId)
		{
			RaiseEvent(new UserAddedItemToCart(itemId));
		}
		
		public void RemoveItem(int itemId)
		{
			RaiseEvent(new UserRemovedItemFromCart(itemId));
		}
		
		// wired up via base class
		protected void Apply(UserAddedItemToCart evnt)
		{
			this.Items.Add(evnt.ProductId);
		}
		
		// wired up via base class
		protected void Apply(UserRemovedItemFromCart evnt)
		{
			this.Items.Remove(evnt.ProductId);
		}
		
		public int[] ItemsInCart
		{
			get { return this.Items.ToArray(); }
		}
	}
