    public class PersonMap : EntityTypeConfiguration<Person>
    {
        HasKey(t => t.Id);
        Property(t => t.Name).IsRequired().HasMaxLength(30);
        ToTable("People");
        Property(t => t.Id).HasColumnName("Id");
        Property(t => t.Name).HasColumnName("Name");
        HasOptional(t => t.PrimaryContact).WithMany(t => t.PrimaryContacts)
                                          .HasForeignKey(t => t.PrimaryContactId);
        HasOptional(t => t.SecondaryContact).WithMany(t => t.SecondaryContacts)
                                            .HasForeignKey(t => t.SecondaryContactId);
    }
    
    
