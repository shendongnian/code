    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // Do not do these things on every post back to the server
            sConn = new SqlConnection(sStr);
            daEmp = new SqlDataAdapter("SELECT * FROM tblEmployee", sConn);
            daDep = new SqlDataAdapter("SELECT * FROM tblDepartment", sConn);
            dsEmp = new DataSet();
            dsDep = new DataSet();
            daEmp.Fill(dsEmp, "tblEmployee");
            daDep.Fill(dsDep, "tblDepartment");
            dsEmp.Tables["tblEmployee"].PrimaryKey = new DataColumn[] { dsEmp.Tables["tblEmployee"].Columns["EmployeeID"] };
            drpDepartments.DataSource = dsDep.Tables["tblDepartment"];
            drpDepartments.DataTextField = "Description";
            drpDepartments.DataValueField = "DeptID";
            drpDepartments.DataBind();
        }
    }
