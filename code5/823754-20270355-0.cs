    private void Page_Load(object sender, System.EventArgs e)
    {
      if (!IsPostBack)
      {
        Session["MyObject"] = new MyCustomObject();
      }
    }
    protected void mybtn_Click(object sender, EventArgs e)
    {
      MyCustomObject myObject = Session["MyObject"] as MyCustomObject;
      myObject.step(1);
    }
    protected void anotherbtn_Click(object sender, EventArgs e)
    {
      MyCustomObject myObject = Session["MyObject"] as MyCustomObject;
      myObject.step(2);
    }
