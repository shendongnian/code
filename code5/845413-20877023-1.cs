    protected void Page_Load(object sender, EventArgs e)
    {  
    var literals = Page.Master.FindControl("SomeID").Controls.OfType<Literal>();
    // Literal ID = (Literal)this.Page.FindControl("SomeID");
     this.literals.Text = SomeStuff();
    }
    private string SomeStuff()
    {
     string javascript = "";
     StringBuilder sb = new StringBuilder();
     sb.Append("Some JavaScript Code");
     sb.Append("dynamically buildup on server side");
     return sb;
    }
