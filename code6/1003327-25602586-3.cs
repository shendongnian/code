    protected void Page_Load(object sender, EventArgs e)
        {
           BindGridView();
        }
    
        public void BindGridView()
        {             
          BLMethods objBLMethods = new BLMethods();
          GridView1.DataSource = objBLMethods.GetPersons();
          GridView1.DataBind();
        }
