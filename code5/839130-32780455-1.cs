	public enum Permission
	{
		NULL,
		EDIT
	}
	public class PermissionStringType : EnumStringType<Permission>
	{
		public PermissionStringType()
			: base(Permission.NULL)
		{
		}
	}
