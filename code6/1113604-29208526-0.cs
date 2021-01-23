    public static IContainer Initialize()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["Ebancomat"].ConnectionString;
    
        return new Container(
            c =>
                {
                    c.For<Ebancomat.DataAdapters.IncomeExpenses.IIncomeExpensesDataAdapter>()
                        .Use<Ebancomat.DataAdapters.IncomeExpenses.IncomeExpensesDataAdapter>()
                        .Ctor<string>("connectionString")
                        .Is(connectionString);
                    c.For<Ebancomat.Repositories.IncomeExpenses.IIncomeExpensesRepository>()
                        .Use<Ebancomat.Repositories.IncomeExpenses.IncomeExpensesRepository>();
                    c.For<IUserStore<ApplicationUser>>().Use<DatabaseUserStore>();
            });
    }
