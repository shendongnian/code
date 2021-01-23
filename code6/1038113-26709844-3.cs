    public class OperatorMapping : EntityTypeConfiguration<Operator>
    {
    	public OperatorMapping()
    	{
    		this.ToTable("Operators");
    		this.Property(t => t.OperatorName).IsRequired().HasColumnName("OperatorName");
    		this.Property(t => t.LoginName).IsRequired().HasColumnName("LoginName");
    		this.Property(t => t.Email).IsRequired().HasColumnName("Email");
    		this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
    		this.Property(t => t.Status).IsRequired().HasColumnName("Status");
    		this.Property(t => t.Password).IsRequired().HasColumnName("Password");
    	}
    }
