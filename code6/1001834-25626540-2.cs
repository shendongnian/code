		public bool isActiveDirectoryDomainServicesInstalled()
		{
			bool bRetval = false;
			try
			{
				uint uID = 110;
				string search = string.Format("SELECT * FROM Win32_ServerFeature WHERE ID = {0}", uID);
				ManagementObjectSearcher oSearcher = new ManagementObjectSearcher("root\\CIMV2", search);
				foreach (var oReturn in oSearcher.Get())
				{
					if ((uint)(oReturn["ID"]) == uID)
					{
						bRetval = true;
						break;
					}
				}
			}
			catch (Exception)
			{
				bRetval = false;
			}
			return bRetval;
		}
