      public class BusinessConfiguration : EntityTypeConfiguration<Business>
      {
            public BusinessConfiguration()
            {
                HasMany(x => x.Images).WithOptional().WillCascadeOnDelete();
                HasOptional(x => x.Logo).WithOptional().WillCascadeOnDelete();
                HasOptional(x => x.Video).WithOptional().WillCascadeOnDelete();
            }
      }
