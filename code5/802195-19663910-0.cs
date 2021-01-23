		public static string getVecozoURL(string dobFormatted, string infodateFormatted, string BSN)
		{
			return getVecozoURL(dobFormatted, infodateFormatted, BSN, "", "", "", 0, "", "Both");
		}
		public static string getVecozoURL(string dobFormatted, string infodateFormatted, string BSN, string insuranceID)
		{
			return getVecozoURL(dobFormatted, infodateFormatted, BSN, insuranceID, "", "", 0, "", "Both");
		}
		public static string getVecozoURL(string dobFormatted, string infodateFormatted, string BSN, string postalcode, int Homenummer)
		{
			return getVecozoURL(dobFormatted, infodateFormatted, BSN, "", "", postalcode, Homenummer, "", "Both");
		}
		public static string getVecozoURL(string dobFormatted, string infodateFormatted,
		string BSN, string insuranceID, string lastname,
		string postalcode, int Homenummer, string Homenummeradd,
		string insuranceType)
		{
			string URL = "";
			if (FCelfproef.BSN(BSN))
			{
				// Do stuff
			}
			else if (!insuranceID.IsEmpty())
			{
				// Do stuff
			}
			else if (postalcode.Length > 4 && Homenummer > 0)
			{
				// Do stuff
			}
			else if (!lastname.IsEmpty())
			{
				// Do stuff
			}
			// Do some other stuff
			return URL;
		}
