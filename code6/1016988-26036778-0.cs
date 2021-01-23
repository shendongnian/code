     public List<Departments> GetAllDepartments()
            {
                try
                {
                    return IDepartment.GetAllDepartments();
    
                  
                }
                catch (System.Exception ex)
                {
                  //  throw ex;  dont throw the same caugted exception
                }
            }
