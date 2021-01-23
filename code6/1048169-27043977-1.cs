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
               //set UserName with UserName from Database value after username &
               //password verification 
               this.UserName = "XYZ User";
            }
