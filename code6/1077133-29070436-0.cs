    public class Resources
    {
		public static System.String NameIsRequired
		{
			get
			{
				if (GeneratedResourceSettings.ResourceAccessMode == ResourceAccessMode.AspNetResourceProvider)
					return (System.String) HttpContext.GetGlobalResourceObject("Resources","NameIsRequired");
				if (GeneratedResourceSettings.ResourceAccessMode == ResourceAccessMode.Resx)
					return ResourceManager.GetString("NameIsRequired");
				return DbRes.T("NameIsRequired","Resources");
			}
		}
		public static System.String AddressIsRequired
		{
			get
			{
				if (GeneratedResourceSettings.ResourceAccessMode == ResourceAccessMode.AspNetResourceProvider)
					return (System.String) HttpContext.GetGlobalResourceObject("Resources","AddressIsRequired");
				if (GeneratedResourceSettings.ResourceAccessMode == ResourceAccessMode.Resx)
					return ResourceManager.GetString("AddressIsRequired");
				return DbRes.T("AddressIsRequired","Resources");
			}
		}
        ... any others in the same resource set
	}
