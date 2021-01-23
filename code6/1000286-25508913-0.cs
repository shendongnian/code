    In the C# class, this would mean that `SupplierAddress` has a collection of `Suppliers` (OR has no reference to `Supplier` at all).
    In this case, your database tables would look like this:
    <!-- language: lang-sql -->
		create table [SupplierAddress]
		(
			[Id] int identity(1,1) primary key clustered,
			[AddressLine1] nvarchar(255) not null
		);
		create table [Supplier]
		(
			[Id] int identity(1,1) primary key clustered,
			[SupplierAddressId] int not null references [SupplierAddress]([Id])
		)
    Your C# classes would look like this:
		public class Supplier
		{	
			public virtual int Id { get; set; }
			
			public virtual SupplierAddress SupplierAddress { get; set; }
			
			public virtual string Name { get; set; }
		}
		
		public class SupplierAddress
		{
			public virtual int Id { get; set; }
			
			public virtual string AddressLine1 { get; set; }
		}
    And your mappings would look like this:
		public class SupplierMap : ClassMap<Supplier>
		{
			public SupplierMap()
			{
				Id(s => s.Id).GeneratedBy.Identity().Column("Id");
				References(s => s.SupplierAddress)
					.Column("SupplierAddressId")
					.Cascade.All();
			}
		}
		
		public class SupplierAddressMap : ClassMap<SupplierAddress>
		{
			public SupplierAddressMap()
			{
				Id(s => s.Id).GeneratedBy.Identity().Column("Id");
				
				Map(s => s.AddressLine1)
					.Column("AddressLine1")
					.Not.Nullable()
					.Length(255);
			}
		}
