    [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
    internal static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);
    
    public static string GetResourceString(string resString)
    {
    	StringBuilder sb = new StringBuilder();
    
    	if(SHLoadIndirectString(resString, sb, -1, IntPtr.Zero) == 0)
    		return sb.ToString();
    
    	return null;
    }
    
    internal sealed class StoreAppObject
    {
    	public StoreAppObject()
    	{
    		this.Protocols = new Dictionary<string, string>();
    	}
    
    
    	public string Name
    	{ get; set; }
    
    	public string Description
    	{ get; set; }
    
    	public string PackageId
    	{ get; set; }
    
    	public string RootFolder
    	{ get; set; }
    
    	public Dictionary<string, string> Protocols
    	{ get; set; }
    }
    
    private void LoadStoreApps()
    {
    	using (RegistryKey hkcr = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry32))
    	{
    		RegistryKey packagesKey = hkcr.OpenSubKey(@"Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\Repository\Packages");
    		string[] packageNames = packagesKey.GetSubKeyNames();
    
    		foreach (string packageName in packageNames)
    		{
    			RegistryKey packageKey = packagesKey.OpenSubKey(packageName);
    
    			if (packageKey != null && packageKey.SubKeyCount > 0)
    			{
    				string[] packageAppNames = packageKey.GetSubKeyNames();
    
    				foreach (string packageAppName in packageAppNames)
    				{
    					RegistryKey packageAppKey = packageKey.OpenSubKey(packageAppName);
    
    					if (packageAppKey != null && packageAppKey.SubKeyCount > 0)
    					{
    						RegistryKey capabilitiesKey = packageAppKey.OpenSubKey("Capabilities");
    
    						if (capabilitiesKey != null)
    						{
    							RegistryKey urlAssociationsKey = capabilitiesKey.OpenSubKey("URLAssociations");
    
    							if (urlAssociationsKey != null)
    							{
    								// My custom class
    								StoreAppObject sao = new StoreAppObject();
    								sao.Name = (string)capabilitiesKey.GetValue("ApplicationName");
    								sao.Description = (string)capabilitiesKey.GetValue("ApplicationDescription");
    								sao.PackageId = (string)packageKey.GetValue("PackageID");
    								sao.RootFolder = (string)packageKey.GetValue("PackageRootFolder");
    
    								string[] urlAssociationNames = urlAssociationsKey.GetValueNames();
    								foreach (string urlAssociationName in urlAssociationNames)
    									sao.Protocols.Add(urlAssociationName, (string)urlAssociationsKey.GetValue(urlAssociationName));
    
    								if (sao.Name.StartsWith("@"))
    									sao.Name = NativeMethods.GetResourceString(sao.Name);
    
    								if (sao.Description.StartsWith("@"))
    									sao.Description = NativeMethods.GetResourceString(sao.Description);								
    							}
    						}
    					}
    				}
    			}
    		}
    	}
    }
