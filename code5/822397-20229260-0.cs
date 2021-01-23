    protected void Page_Load(object sender, EventArgs e)        
    {
      if (!Page.IsPostBack && Session["listSession"] != null)
      {
        var myBall = (List<Ball>)Session["listSession"];
        foreach (var ball in myBall)
          DropDownList1.Items.Add(item.getBallInfo());
      }
    }
