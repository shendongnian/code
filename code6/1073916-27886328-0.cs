    	public class Rootobject
	{
		public Person[] people { get; set; }
	}
	public class Person
	{
		public string url { get; set; }
		public string userName { get; set; }
		public bool enabled { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string jobtitle { get; set; }
		public string organization { get; set; }
		public string organizationId { get; set; }
		public string location { get; set; }
		public string telephone { get; set; }
		public string mobile { get; set; }
		public string email { get; set; }
		public string companyaddress1 { get; set; }
		public string companyaddress2 { get; set; }
		public string companyaddress3 { get; set; }
		public string companypostcode { get; set; }
		public string companytelephone { get; set; }
		public string companyfax { get; set; }
		public string companyemail { get; set; }
		public string skype { get; set; }
		public string instantmsg { get; set; }
		public string userStatus { get; set; }
		public Userstatustime userStatusTime { get; set; }
		public string googleusername { get; set; }
		public int quota { get; set; }
		public int sizeCurrent { get; set; }
		public bool emailFeedDisabled { get; set; }
		public string persondescription { get; set; }
		public string avatar { get; set; }
	}
	public class Userstatustime
	{
		public DateTime iso8601 { get; set; }
	}
