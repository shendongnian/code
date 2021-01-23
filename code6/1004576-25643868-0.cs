    public partial class ucTZones : UserControl{
                /// <summary>
                /// Accessor for the time zone drop-down.
                /// </summary>
                public int ddlProp
                {
                    get
                    {
                        // your variable to get the value
                    }
                    set
                    {
                        // your variable to assign
                    }
                }
        
                protected void Page_Load(object sender, EventArgs e)
                {
                    if(!ispostback)
                      BindDropDown();
        
                  }
        
                private void BindDropDown()
                {
                  ddl.datasource =somelist;
                  ddl.DataBind();
    ddl.SelectedValue = ddlProp;
                }
            }
