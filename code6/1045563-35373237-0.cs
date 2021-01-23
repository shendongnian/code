    public class PersonMap : IEntityTypeConfiguration<Person>
    {
    	public void Map(EntityTypeBuilder<Person> builder)
    	{
    		builder.HasKey(x => x.Id);
    		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    	}
    }
