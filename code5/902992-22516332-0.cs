     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Attributes.Add("onblur", "alert('hi User')");
        }
    }
