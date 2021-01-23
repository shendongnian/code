     public List<Departments> GetAllDepartments()
        {
            List<Departments> listDepartments = null;
            try
            {
                listDepartments = IDepartment.GetAllDepartments();       
            }
            catch (System.Exception ex)
            {
               //Handle your exception
            }
            return listDepartments; 
        }
