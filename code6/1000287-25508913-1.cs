    In this case, your database tables would look like this:
    <!-- language: lang-sql -->
		create table [SupplierAddress]
		(
			[Id] int identity(1,1) primary key clustered,
			[AddressLine1] nvarchar(255) not null,
			[SupplierId]  int not null
		);
		create table [Supplier]
		(
			[Id] int identity(1,1) primary key clustered,
			[SupplierAddressId] int references [SupplierAddress]([Id])
		);
		alter table [SupplierAddress] 
			add constraint [FK_SupplierAddress_Supplier] 
			foreign key ([SupplierId]) references [Supplier]([Id])
    Your C# classes would look like this:
		public class Supplier
		{	
			private SupplierAddress supplierAddress;
			
			public virtual int Id { get; set; }
			
			public virtual SupplierAddress SupplierAddress 
			{
				get { return this.supplierAddress; }
				set 
				{ 
					this.supplierAddress = value;
					this.supplierAddress.Supplier = this;
				}
			}
			
			public virtual string Name { get; set; }
		}
		
		public class SupplierAddress
		{
			public virtual int Id { get; set; }
			
			public virtual string AddressLine1 { get; set; }
			
			public virtual Supplier Supplier { get; set; }
		}
    And your mappings would look like this:
		public class SupplierMap : ClassMap<Supplier>
		{
			public SupplierMap()
			{
				Id(s => s.Id).GeneratedBy.Identity().Column("Id");
				HasOne(s => s.SupplierAddress).PropertyRef(s => s.Supplier)
					.Access.CamelCaseField()
					.Cascade.All();
			}
		}
		
		public class SupplierAddressMap : ClassMap<SupplierAddress>
		{
			public SupplierAddressMap()
			{
				Id(s => s.Id).GeneratedBy.Identity().Column("Id");
				Map(s => s.AddressLine1).Column("AddressLine1");
				References(s => s.Supplier).Column("SupplierId").Unique();
			}
		}
    Note that when `Supplier.SupplierAddress` is `set`, the address's `Supplier` property is set.
