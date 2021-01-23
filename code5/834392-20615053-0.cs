	public static class Localise
	{
		private const string STRINGS_ROOT = "MyPCL.strings.strings";
		public static string GetString(string sID, string sLocale)
		{
			string sResource = STRINGS_ROOT + "_" + sLocale;
			Type type = Type.GetType(sResource);
			if (type == null)
			{
				if (sLocale.Length > 2) {
					sResource = STRINGS_ROOT + "_" + sLocale.Substring(0, 2); // Use first two letters of region code
					type = Type.GetType(sResource);
				}
			}
			if (type == null) {
				sResource = STRINGS_ROOT;
				type = Type.GetType(sResource);
				if (type == null)
				{
					System.Diagnostics.Debug.WriteLine("No strings resource file when looking for " + sID + " in " + sLocale);
					return null; // This shouldn't ever happen in theory
				}
			}
			ResourceManager resman = new ResourceManager(type);
			return resman.GetString(sID);
		}
	}
