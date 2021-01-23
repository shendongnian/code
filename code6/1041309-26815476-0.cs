    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
    	public UserInfoMap()
    	{
    		ToTable("UserInfo");
    		HasKey(m => m.UserInfoId );
    	}
    }
