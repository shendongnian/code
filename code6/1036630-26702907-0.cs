    ISessionFactory factory = SessionFactory.CreateSessionFactory();
            ISession session = factory.OpenSession();
            var res = session.Query<Client>()
                .Select(
                    x => new object[]{
                        x.Transactions.Count(),
                        x.Transactions.Sum( y => y.SomeAmount),
                    }
                )
                .ToList();
