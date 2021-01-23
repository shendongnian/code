	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace WebApplication1
	{
		public partial class MyMasterPage : System.Web.UI.MasterPage
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				Page.Error += Page_Error;
			}
			private void Page_Error(object sender, EventArgs e)
			{
				var ex = Server.GetLastError();
				// do something with exception
				Debug.WriteLine(ex);
			}
		}
	}
