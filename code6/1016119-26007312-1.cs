    using System;
    using System.Data;
    using System.Data.SqlClient;
    class Program
    {
    static void Main()
    {
        string connectionString =
            "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";
        // Provide the query string with a parameter placeholder. 
        string queryString =
            "UPDATE [dbo].[USR_Users] SET [Active] = 1 WHERE Id = 1";
       
        using (SqlConnection connection =
            new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
           
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
