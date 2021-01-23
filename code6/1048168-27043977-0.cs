    public string UserName
            {
                get
                {
                    //return the object from session
                    return (string)Session["UserName"];
                }
     
                set
                {
                    Session["UserName"] = value;
                }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                this.UserName = "XYZ User";
            }
