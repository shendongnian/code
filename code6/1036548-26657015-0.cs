	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace WebFormsTestApp
	{
		public partial class _Default : Page
		{
			protected string Name = "Alice Student";
			protected decimal GPA = 3.84M;
			protected List<string> Classes = new List<string>() { "World History", "Algebra II", "English", "Phys Ed", "Latin I", "Home Economics" };
			protected School School = new School() { Name = "Jefferson High School", County = "Hamilton County", Ranking = 5 };
		}
		public class School
		{
			public string Name { get; set; }
			public string County { get; set; }
			public int Ranking { get; set; }
		}
	}
