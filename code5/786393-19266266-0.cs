    protected override void Page_Load(object sender, System.EventArgs e)
    {
        base.Page_Load(sender, e);
        
        if (IsPostBack) //If it is a postback close the popup
        {
            StringBuilder scriptStringB = new StringBuilder();
            scriptStringB.Append("<script type=\"text/javascript\">");
            scriptStringB.Append(" CloseiFrameThroughParent();");
            scriptStringB.Append("</script>");
            RegisterClientStartupScript("CloseiFrameThroughParent", scriptStringB.ToString());
        }
    }
