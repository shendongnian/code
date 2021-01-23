    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetCountryName().ToLower() == "india")
                {
                    DivTwo.Visible = true;
                }
                else
                {
                    DivOne.Visible = true;
                }
            }
        }
