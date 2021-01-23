	public override void OnModelCreating()
	{
		this.Configurations.Add(new CustomerMap());
		this.Configurations.Add(new CustomerChangeMap());
	}
