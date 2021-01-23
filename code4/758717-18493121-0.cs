	public class MyDto
	{
		// Values: Y, N, and NULL
		public string SomeDbField { get; set; }
		public bool SomeDbFieldAccessor
		{
			get { return (SomeDbField != null && SomeDbField == "Y"); }
			set { SomeDbField = value ? "Y" : "N"; }
		}
	}
