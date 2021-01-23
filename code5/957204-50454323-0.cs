    private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IVisitProcessor>().To<VisitProcessor>().InThreadScope();
            kernel.Bind<IPatientProcessor>().To<PatientProcessor>().InThreadScope();
            kernel.Bind<IDbConnectionFactory>().To<SqlConnectionFactory>().Named("Warehouse").WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DataWarehouse"].ConnectionString);
        }
