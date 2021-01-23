		public class ParentGroupMap : EntityTypeConfiguration<ParentGroup>
		{
			public ParentGroupMap()
			{
				HasMany(pg => pg.Children1)
					.WithOptional(c => c.ParentGroup1)
					.HasForeignKey(c => c.ParentGroup1Id);
				HasMany(pg => pg.Children2)
					.WithOptional(c => c.ParentGroup2)
					.HasForeignKey(c => c.ParentGroup12d);
			}
		}
