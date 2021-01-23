	public partial class DDC : System.Web.UI.MasterPage
	{
		public string lblLogin_Text
		{
			get { return lblLogin.Text; }
			set { lblLogin.Text = value; }
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var result = (Session["AuthenticationResult"] as AuthenticationResult);
				if (result != null && result.Authenticated)
				{
                    this.User = result;
					lblLogin_Text = String.Form("{1} {2}, result.FirstName, result.LastName);
				}
				else
				{
					lblLogin_Text = String.Empty;
				}
			}
		}
	}
