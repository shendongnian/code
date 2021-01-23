    internal sealed class Configuration : DbMigrationsConfiguration<IBCF.Core.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(IBCF.Core.ApplicationDBContext context)
        {
            //Initialize managers
            var userManager = new UserManager<Business>(new UserStore<Business>(context));
            //Do something to populate your csvs variable
            foreach (string csv in csvs)
            {
                using (CsvReader reader = new CsvReader(csv))
                {
                    foreach (string[] values in reader.RowEnumerator)
                    {
                        var business = new Business
                        {
                            BusinessName = values[0],
                            Email = values[1],
                            Address = values[2],
                            City = values[3],
                            StateID = states.Single(s => s.StateCode == values[4]).StateID,
                            Zip = values[5],
                            Phone = values[6],
                            Fax = values[7],
                            SICCode = values[8],
                            Description = values[9],
                            Website = values[10]
                        };
                        userManager.Create(business, "MyPassword")
                    }
                }
            }
            context.SaveChanges();
        }
    }
