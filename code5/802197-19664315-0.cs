	class VecozoURLFormater
	{
		public string DobFormatted { get; private set; }
		public string InfodateFormatted { get; private set; }
		public string InsuranceType { get; private set; }
		public VecozoURLFormater(string dobFormatted, string infodateFormatted, string insuranceType = "Both")
		{
			DobFormatted = dobFormatted;
			InfodateFormatted = infodateFormatted;
			InsuranceType = insuranceType;
		}
		public string FromBSN(string BSN){/*...*/}
		public string FromInsurranceID(string insuranceID){/*...*/}
		public string FromLastname(string lastname){/*...*/}
		public string FromPostalcode(string postalcode, int Homenummer, string Homenummeradd = "") {/*...*/}
	}
