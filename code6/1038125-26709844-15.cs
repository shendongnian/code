    public class OperatorMapping : EntityTypeConfiguration<Operator>
    {
    	public OperatorMapping()
    	{
    		this.ToTable("Operators");
    		this.Property(t => t.OperatorName).IsRequired().HasColumnName("OperatorName");
    		this.HasKey(t => t.LoginName).Property(t => t.LoginName).HasColumnName("LoginName");
    		this.Property(t => t.Email).IsRequired().HasColumnName("Email");
    		this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
    		this.Property(t => t.Status).IsRequired().HasColumnName("Status");
    		this.Property(t => t.Password).IsRequired().HasColumnName("Password");
    	}
    }
