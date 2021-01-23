    /* This approach will allow for parameters, avoiding Sql Injection.
       It also shows the 'TOP' for result, to limit the data your pulling.  The larger 
       the table, the slower the application. (Just example, tweak for real world.)
    */
    string query = "SELECT TOP 50 * FROM [Database] WHERE ([Id] = @Id AND [Type] = @Type);";
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbInConfig"].ConnectionString))
         using(SqlCommand command = new SqlCommand(query, connection))
         {
              /*  The 'Using' will implement IDispose, which will save
                  you resources, as once an item it out of scope will be 
                  collected by Garbage Collection.
               */
    
               connection.Open(); // Self explanatory, open your database connection.
               
               // You can declare a parameter should you need one like this:
               command.Parameters.AddWithValue("@Id", id);
    
              /* The downfall with 'AddWithValue' is it attempts to infer
                 the database type, which can be wrong. */
    
              command.Parameters.Add("@Id", SqlDbType.Int).Value = type;
    
              /* The generic add has you manually specifying the type,
                 less room for error especially with big data.
    
              // Execute a Reader, to Read the data.
              using(SqlDataReader reader = command.ExecuteReader())
                   while(reader.Read())
                   {
                        // Within this scope, you can transmit data anyway you'd like.
                        if(reader["Column"] != DBNull.Value)
                             Console.WriteLine(reader["Column"].ToString());
    
                        /* You could populate a data model, or list to send 
                           to console in a tabular format.  Or do what I did
                           above which would show them one at a time. */
                   }
         }
