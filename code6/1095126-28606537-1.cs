    private void Page_Load(object sender, System.EventArgs e)
    {
    HtmlAnchor HA = new HtmlAnchor();
    HA.ServerClick += new EventHandler(linkclickeve1);
    HtmlAnchor HA2 = new HtmlAnchor();
    HA2.ServerClick += new EventHandler(linkclickeve2);
    }
    protected void linkclickeve1(object sender, System.EventArgs e)
    {
    }
  
    protected void linkclickeve2(object sender, System.EventArgs e)
    {
    }
