    protected void btnSave_Click(object sender, EventArgs e)
    {
    	 using (var db = DepartmentContext() )
    	 {
    		var name = new SqlParameter("@name, txtDepartment.text.trim());
    		
    		//to get this to work, you will need to change your select inside dbo.insert_department to include name in the resultset
    		var department = db.Database.SqlQuery<Department>("dbo.insert_department @name", name).SingleOrDefault();
    
           //alternately, you can invoke SqlQuery on the DbSet itself:
           //var department = db.Departments.SqlQuery("dbo.insert_department @name", name).SingleOrDefault();
    		
    		int departmentID = department.DepartmentId;
    	 }
    }
