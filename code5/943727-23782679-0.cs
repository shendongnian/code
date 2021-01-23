    public calss Guid1 {
        public Guid Guid { get; set; }
    }
    public class Category {
        public virtual long Id { get; set; }
        public Guid1 Guid { get; set; }
        public string Name { get; set; }
    }
    public class CategoryConfiguration:EntityTypeConfiguration<Category> {
        public CategoryConfiguration () {
            HasKey(entity => entity.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasReqired(x => x.Guid1);
        }
    }
    public class Guid1Configuration:EntityTypeConfiguration<Guid1> {
        public Guid1Configuration () {
            HasKey(x => x.Guid);
            Property(x => x.Guid).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
