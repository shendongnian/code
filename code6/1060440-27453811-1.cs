    class UserAddressConfiguration : EntityTypeConfiguration<UserAddress>
    {
    	public UserAddressConfiguration()
    	{
    		HasRequired(m => m.User).WithMany().HasForeignKey(m => m.ObjectId);
    	}
    }
    class ContractorAddressConfiguration : EntityTypeConfiguration<ContractorAddress>
    {
    	public ContractorAddressConfiguration()
    	{
    		HasRequired(m => m.Contractor).WithMany().HasForeignKey(m => m.ObjectId);
    	}
    }
