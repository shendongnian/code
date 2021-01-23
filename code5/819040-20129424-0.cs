    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack) {
       MySqlCommand cd = new MySqlCommand("SELECT * FROM pets", cs);
       cs.Open();
       MySqlDataReader ddl = cd.ExecuteReader();
       DdPetPist.DataSource = ddl;
       DdPetPist.DataValueField = "Specie";
       DdPetPist.DataTextField = "Specie";
       DdPetPist.DataBind();
       cs.Close();
       cs.Dispose();
      }
    }
