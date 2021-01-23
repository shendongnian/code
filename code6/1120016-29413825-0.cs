	public class Employee:EmployeeBase
	{
		private string _EId;
		private string _EName;
		private string _Designation;
		private EmployeeBase[] _Expirence;
		public string EId
		{
			get { return _EId; }
			set { _EId = value; }
		}
		public string EName
		{
			get { return _EName; }
			set { _EName = value; }
		}
		public string Designation
		{
			get { return _Designation; }
			set { _Designation = value; }
		}
		public Expirence[] MyExpirence
		{
			get { return _Expirence; }
			set { _Expirence = value; }
		}
	}
