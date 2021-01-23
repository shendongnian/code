    protected void Page_Load(object sender, EventArgs e)
        {
             
            btn_Edit.Enabled=false ;
            lbl_error.Visible = false;
            if (!Convert.ToBoolean(Session["logedin"]))
            {
                Response.Redirect("Default.aspx");
            }
            hiddenitems.Visible = false;
            if (Page.IsPostBack)
            {   btn_Search.Visible = true;
                lbtn_advacedsearch.Visible = true;
                drp_Property.Visible = true;
                txt_pvalue.Visible = true;
                Label5.Visible = true;
                Label4.Visible = true;
                
            }
            img_Logo.Visible = false;
            //imgLogo.Src = "pics/Manufacturer_Logo/selectmodel.jpg";
            SqlConnectionStringBuilder kcestring = new SqlConnectionStringBuilder();
            kcestring.DataSource = @"localhost";
            kcestring.InitialCatalog = "KCE";
            kcestring.UserID="sa";
            kcestring.Password="123";
            //kcestring.IntegratedSecurity = true;
            SqlDataAdapter empper = new SqlDataAdapter("sp_GetEmployeepermissionsByID", kcestring.ToString());
            SqlParameter employeeID = new SqlParameter("employeeID", SqlDbType.BigInt);
            employeeID.Value = Session["employeeid"];
            empper.SelectCommand.Parameters.Add(employeeID);
            empper.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable da = new DataTable();
            empper.Fill(da);
        }
