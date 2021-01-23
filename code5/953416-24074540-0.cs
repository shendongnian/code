	public string DisplayShippingAddress
	{
		get
		{
			return String.Join(Environment.NewLine, new []
			{
				this.Address1, this.Address2, this.Address3,
				this.City, this.ZIPCode, this.County,
				this.State, this.Country
			});
		}
	}
