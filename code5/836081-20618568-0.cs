      public Int32 MyNumber
            {
                get
                {
                    if (ViewState["MyNumber"] != null)
                    {
                        return (Int32)ViewState["MyNumber"];
                    }
    
                    return 0;
                }
                set
                {
                    ViewState["MyNumber"] = value;
                }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                Response.Write(MyNumber.ToString()); // Result now is 23 :)
            }
    
            protected override void OnLoad(EventArgs e)
            {
                
                // I replaced the order of the code here to get the value of the Viewstate in MyNumber property ..
                if (!this.IsPostBack)
                {
                    MyNumber = 23;
                }
    
                base.OnLoad(e);
            }
    
            protected override void OnPreRender(EventArgs e)
            {
                base.OnPreRender(e);
    
                var numberValue = MyNumber;
            }
