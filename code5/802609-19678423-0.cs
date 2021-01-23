    if (!IsPostBack)
    {
        Session["gridview"] = DataBindByDataSet();
        GVPolice.DataSource = Session["gridview"];
        GVPolice.DataBind();
    
        using (var connAdd = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            connAdd.Open();
            var sql = "select policeid as [Police ID], fullname as [Full Name], contact as [Contact], email as [Email], nric as [NRIC],  address as [Address], handle as [HandleCase], postedto as [Posted To] from PoliceAccount where status='available'";
            using (var cmdAdd = new SqlDataAdapter(sql, connAdd))
            {
                DataSet dsSel = new DataSet();
                cmdAdd.Fill(dsSel);
                GVPolice.DataSource = dsSel;
                GVPolice.DataBind();
            }
            .....
            .....
        }
    }
