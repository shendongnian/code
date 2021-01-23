    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data;
    namespace MvcApplication.Models
    {
    public class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
        string strConnection = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
        public void insert(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                string sql = "insert into myTable values('" + employee.FName + "','" + employee.LName + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public string GetEmployee(int Id) ...
    }
    }
