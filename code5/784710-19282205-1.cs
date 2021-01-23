	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//Fake DataTable below.
				//SqlDataSource can be configured to generate a DataTable,
				//Or you can use a DataAdapter
				DataTable dt = new DataTable();
				DataColumn dc1 = new DataColumn("Name");
				DataColumn dc2 = new DataColumn("Id");
				DataColumn dc3 = new DataColumn("Selected");
				dc3.DataType = System.Type.GetType("System.Boolean");
				dt.Columns.Add(dc1);
				dt.Columns.Add(dc2);
				dt.Columns.Add(dc3);
				dt.Rows.Add(new object[] { "John Doe", "135681", true });
				dt.Rows.Add(new object[] { "Billy Joe", "66541", false });
				dt.Rows.Add(new object[] { "Joe Shmoe", "7783654", true });
				dt.Rows.Add(new object[] { "Don Sean", "1332451", true });
				dt.Rows.Add(new object[] { "Moe H", "632451", false });
				dt.Rows.Add(new object[] { "Clicky", "0234354", true });
				//Bind DataTable to Repeater
				Repeater1.DataSource = dt;
				Repeater1.DataBind();
			}
		}
		protected void Update_Button_Click(object sender, EventArgs e)
		{
			List<Person> Listy = new List<Person>();
			ControlCollection CC = Repeater1.Controls;            
			foreach (RepeaterItem RI in CC)
			{
				Person p = new Person();
				foreach (Control c in RI.Controls)
				{
					if (c is System.Web.UI.WebControls.CheckBox)
					{
						if (((System.Web.UI.WebControls.CheckBox)c).Checked)
							p.Selected = true;
						else p.Selected = false;                        
					}
					if (c is System.Web.UI.WebControls.Label)
					{
						p.Name = ((System.Web.UI.WebControls.Label)c).Text;
					}
				}
				Listy.Add(p);
			}
			UpdateDatabase(Listy);
		}
		protected void UpdateDatabase(List<Person> L)
		{
			foreach (Person p in L)
			{
				string update = "UPDATE [Table] SET [Selected] = " + p.Selected + "WHERE [Name] = " + p.Name;
				// Execute statement
			}
		}
	}
	public class Person
	{
		public string Name { get; set; }
		//public int ID { get; set; }
		public bool Selected { get; set; }
	}
