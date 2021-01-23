    public class EmployeeDAO
    {
        public void EmployeeInsert(Employee emp)
        {
            try
            {
               //Insert a Employee
            }
            catch (Exception ex)
            {
                string message = string.Format("Record doesn't exists for Id {0}", id);
                throw new Exception(message, ex);
            }
        }
    }
