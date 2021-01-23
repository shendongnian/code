    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ResPlannerContext"].ConnectionString))
    {
        connection.Open();
        using (ResPlannerContext context = new ResPlannerContext(connection, false))
        {
            using (var tran = context.Database.BebinTransaction() ) {
                var data = context.Activities.Where(x => x.StartDate < DateTime.Today);
                Console.WriteLine("Count: " + data.Count());
                tran.Commit();
            }
        }
    }
