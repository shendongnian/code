    using System;
    using System.Data;
    using System.Data.SqlClient;
    
        class Program
        {
            static void Main(string[] args)
            {
                string sqlConnectString = "Data Source=(local);" +
                    "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
    
                string sqlSelect = "SELECT TOP 3 * FROM Sales.SalesOrderHeader;" +
                    "SELECT TOP 3 * FROM Sales.SalesOrderDetail";
                int rsNumber;
                SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
                DataSet ds = new DataSet( );
                da.Fill(ds);
    
                rsNumber = 0;
    
                using (SqlConnection connection = new SqlConnection(sqlConnectString)){
                    SqlCommand command = new SqlCommand(sqlSelect, connection);
                    connection.Open( );
                    SqlDataReader dr = command.ExecuteReader( );
    
                    rsNumber = 0;
                    do{
                        Console.WriteLine("Result set: {0}", ++rsNumber);
                        while (dr.Read( )){
                            Console.WriteLine("{0}, {1}, {2}", dr[0], dr[1], dr[2]);
                        }
                        Console.WriteLine(Environment.NewLine);
                    } while (dr.NextResult( ));
                }
            }
        }
