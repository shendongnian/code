    public void Save(tblUser objUser)
    {
      using (TransactionScope ts= new TransactionScope())
      {    
        MYDB.AddTotblUsers(objUser);
        MYDB.SaveChanges(); 
    
        tblEmployee tbEmp = this.GetEmployeeRecordById(objUser.EmpId);
        if(tbEmp!=null)
          tbEmp.IsUser = true;
        MYDB.SaveChanges();
        
        ts.complete();
      }
    }
