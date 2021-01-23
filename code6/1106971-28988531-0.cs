 	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			GlobalVariables.surname = Request.QueryString["surname"];
			GlobalVariables.name = Request.QueryString["name"];
			GlobalVariables.gender = Request.QueryString["gender"];
			GlobalVariables.age = int.Parse(Request.QueryString["age"]);
			Label1.Width = 700;
		}
		else
		{
			DoPostBackStuff();
		}
	}
	private void DoPostBackStuff()
	{
		var f0= new FileStream(Server.MapPath("./key.txt"), FileMode.Open, FileAccess.Read);
		StreamReader sr = new StreamReader(f0); 
		//..... 
		sr.Close();
		sr.Dispose();
	}
