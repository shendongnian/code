    namespace DAL
    {
        public class DAL
        {
            public const string CADENA_CONEXION = "Data Source=localhost;" +
                "Initial Catalog=Company" +
                "Integrated Security=false" +
                "UID=root PWD=root";
            public SqlConnection con;
            public SqlCommand command;
    
        public DAL()
        {
            con = new SqlConnection();
            con.ConnectionString = CADENA_CONEXION;
        }
    
        public Boolean addEmployee(Employee emp)
        {
            try
            {
                /*String sqlInsertString = "INSERT INTO Employee (FirstName, LastName, ID, " + 
               "Designation) VALUES ("+e.firstName+","+ e.lastName+","+e.empCode+","+e.designation+")";*/
                string sqlInsertString =
                    "INSERT INTO Employee (FirstName, LastName, ID, " +
                    "Designation) VALUES (@firstName, @lastName, @ID, @designation)";
                command = new SqlCommand();
                command.Connection=con;
                command.Connection.Open();
                command.CommandText = sqlInsertString;
    
                SqlParameter firstNameparam = new SqlParameter("@firstName", emp.FirstName);
                SqlParameter lastNameparam = new SqlParameter("@lastName", emp.LastName);
                SqlParameter IDparam = new SqlParameter("@ID", emp.EmpCode);
                SqlParameter designationParam = new SqlParameter("@designation", emp.Designation);
    
                command.Parameters.AddRange(new SqlParameter[]{
                firstNameparam,lastNameparam,IDparam,designationParam});
    
                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
    
            return true;
        }
    }
