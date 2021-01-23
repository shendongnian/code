    public void IDepartmentDataSource.DeleteDepartment(int id)
    {
    
       Department itemToDelete = this.GetDepartmentById(id);
       if (itemToDelete != null)
       {
         this.Departments.Remove(itemToDelete);                
       }
    
     }
