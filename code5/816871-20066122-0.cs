    public void Page_Load(object sender, EventArgs e) 
    {
      if (!IsPostBack)
      {
        var myObj = GetdataFromDb();
        TextBox1.Text = myObj.Subject;
        TextBox2.Text = myObj.Desctiption;
      }
    }
