    //Domain Class
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    
    namespace BanjoOnMyKnee.Models
    {
        public class DomainModel
        {
            public string connectionString = ".\\SQLEXPRESS; Initial-Catalog=YourDBName; Integrated-Security=true";
            public void CreateSomething(ViewModel model)
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("",connection))
                {
                    command.CommandText = "insert into Names values(@Name)";
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.ExecuteNonQuery();
                }
            }
    
            public ViewModel FindSomething(int id)
            {
                var model = new ViewModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandText = "select * from Names where Id=@Id";
                    command.Parameters.AddWithValue("@Id",id);
                    SqlDataReader reader = command.ExecuteReader();
                    model.Id = id;
                    model.Name = reader["Name"].ToString();
                }
                return model;
            }
    
            public void DeleteSomething(ViewModel model)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandText = "delete from Names where Id=@Id";
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.ExecuteNonQuery();
                }
            }
    
            public void EditSomething(ViewModel model)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandText = "Update Names set Name=@Name where Id=@Id";
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
