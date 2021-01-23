      private void button1_Click(object sender, EventArgs e)
        {
            //Reading conection from App Settings
            //this insert values from 20 to 29
            ExecuteSqlTransaction(Settings.Default.Conexion,20);
            //this must insert values from 15 to 24
            //But at 20 a PrimaryKey infraction raise exception and rollback
            ExecuteSqlTransaction(Settings.Default.Conexion, 15);
    
        }
    private static void ExecuteSqlTransaction(string connectionString,int start)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction;
            transaction = connection.BeginTransaction("SampleTransaction");
            // Must assign both transaction object and connection 
            // to Command object for a pending local transaction
            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandText = "INSERT INTO [dbo].[Coches] ([IdCoche],[Marca],[Modelo],[Version]) VALUES (@IdCoche,@Marca,@Modelo,@Version)";
            command.Parameters.AddRange(new SqlParameter[]{
                    new SqlParameter("@IdCoche",""),
                    new SqlParameter("@Marca",""),
                    new SqlParameter("@Modelo",""),
                    new SqlParameter("@Version","")
                });
            try
            {
                for (int i = start; i < start + 10; i++)
                {
                    command.Parameters["@IdCoche"].Value = "IdCoche"+i.ToString();
                    command.Parameters["@Marca"].Value = "Marca" + i.ToString(); ;
                    command.Parameters["@Modelo"].Value = "Modelo" + i.ToString(); ;
                    command.Parameters["@Version"].Value = "Version" + i.ToString(); ;
                    command.ExecuteNonQuery();
                }
                // Attempt to commit the transaction.
                transaction.Commit();
                Console.WriteLine("10 records are written to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
                // Attempt to roll back the transaction. 
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    // This catch block will handle any errors that may have occurred 
                    // on the server that would cause the rollback to fail, such as 
                    // a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
        }
    }
