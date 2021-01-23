		public class ChildMap : EntityTypeConfiguration<Child>
		{
	        	public ChildMap()
	        	{
				HasKey(t => t.Value);
				HasOptional(c => c.ParentGroup1)
					.WithMany()
					.HasForeignKey(c => c.ParentGroup1Id);
				HasOptional(c => c.ParentGroup2)
					.WithMany()
					.HasForeignKey(c => c.ParentGroup2Id);
			}
		}
