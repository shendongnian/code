    protected void btnSave_Click(object sender, EventArgs e)
    {
    	 using (var db = DepartmentContext() )
    	 {
    		var department = new Department();
    		
    		department.Name = txtDepartment.text.trim();
    		
    		db.Departments.add(department);
    		db.SaveChanges();
    		
    		// EF will populate department.DepartmentId
    		int departmentID = department.DepartmentId;
    	 }
    }
