    public void Save(tblUser objUser)
    {
     MYDB.AddTotblUsers(objUser);
     MYDB.SaveChanges(); 
    
     tblEmployee tbEmp = this.GetEmployeeRecordById(objUser.EmpId);
     if(tbEmp!=null)
       tbEmp.IsUser = true;
    
    }
