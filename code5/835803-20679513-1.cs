            AreaRegistration.RegisterAllAreas();
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=.\someserver; Integrated Security=False;User ID=myuser;Password=mypass; MultipleActiveResultSets=True");
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
