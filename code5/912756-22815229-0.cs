    public class BasePageClass : System.Web.UI.Page
	{
		public List<string> LookupValues
		{
			get
			{
				if (ViewState["LookupValues"] == null)
				{
					/*
						* create default instance here or retrieve values from Database for one time purpose
						*/
					ViewState["LookupValues"] = new List<string>();
				}
				return ViewState["LookupValues"] as List<string>;
			}
		}
	}
	public partial class WebForm6 : BasePageClass
	{
		protected void Page_Load(object sender, EventArgs e)
		{			
		}
		protected void MyButton_Click(object sender, EventArgs e)
		{
			//access lookup properties
			List<string> myValues = LookupValues;
		}
	}
 
