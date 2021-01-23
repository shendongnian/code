		public SalesOrder(IGrouping<string, SalesOrder> Group)
		{
			this.Name = Group.Key;
			this.Price = Group.First().Price;
			this.Quantity = Group.Sum(g => g.Quantity);
			// do all other properties here too
		}
