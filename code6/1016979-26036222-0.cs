    public class DbHandler
    {
        public string DateChanges()
        {
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            var connectionstring =                    ConfigurationManager.ConnectionStrings["attendancemanagement"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionstring);
            string query = "select count(Employee_id) from employee_details";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            var result = result.ToString();
    
            conn.Close();
    
            return result;
        }
    }
