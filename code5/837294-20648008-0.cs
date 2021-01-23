    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // populates Departments dropdownlist
            using (dbOrganizationEntities1 myEntities = new dbOrganizationEntities1())
            {       
               var allDepartments = from tbDepartments in myEntities.tbDepartments
                        select tbDepartments;
               ddlDepartments.DataSource = allDepartments;
               ddlDepartments.DataValueField = "DepartmentID";
               ddlDepartments.DataTextField = "DepartmentName";
               ddlDepartments.DataBind();
            }
        }
    }
