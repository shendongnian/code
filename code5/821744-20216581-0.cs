                if (!Page.IsPostBack)
                {
                    int Monitor_year = 2010;
                    
                    FillYears(ddl_year_B); // The content of this method is what i desribed ealier in my post.
                    FillYears(ddl_year_A);
    
                    if (Session["CurrentCompareYearWithSessionKey"] == null)
                        Session["CurrentCompareYearWithSessionKey"] = Monitor_year - 1;
    
                    ddl_year_B.SelectedValue = Session["CurrentCompareYearWithSessionKey"].ToString();//Works as expected
    
                    if (Session["CurrentSelectedYearSessionKey"] == null)
                        Session["CurrentSelectedYearSessionKey"] = Monitor_year;
    
                    ddl_year_A.SelectedValue = Session["CurrentSelectedYearSessionKey"].ToString();// Does not work as expected
                }
    
    
    
    //-----------
    
            protected void FillYears(DropDownList ddl_year)
            {
                if (ddl_year.Items.Count == 0)
                {
                    int current_year = System.DateTime.Now.Year;
                    for (int i = 1; i < 11; i++)
                    {
                        ListItem li = new ListItem((current_year - i).ToString(), (current_year - i).ToString());
    
                        ddl_year.Items.Add(li);
                    }
    
                    ddl_year.SelectedIndex = 0;
                }
            }
    
    //---------------------  aspx page
    
            <asp:DropDownList ID="ddl_year_B" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddl_year_A" runat="server"></asp:DropDownList>
    
    The value of ddl_year_B and ddl_year_A is 2009 and 2010 respectively
