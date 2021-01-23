    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ResPlannerContext"].ConnectionString))
    {
        connection.Open();
        SqlTransaction trans = connection.BeginTransaction();
        using (ResPlannerContext context = new ResPlannerContext(trans.Connection, false))
        {
            context.Database.UseTransaction(trans);
            var data = context.Activities.Where(x => x.StartDate < DateTime.Today);
            Console.WriteLine("Count: " + data.Count());
        }
    }
