     private static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.Configure();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            ITransaction tx1 = session.BeginTransaction();
            var c1 = new Cat();
            c1.id = "cat1";
            c1.name = "Fluffy";
            c1.sex = "f";
            c1.weight = new Decimal(3.2);
            var c2 = new Cat();
            c2.id = "cat2";
            c2.name = "Mittens";
            c2.sex = "m";
            c2.weight = new Decimal(4.3);
            try
            {
                session.Save(c1);
                session.Save(c2);
                tx1.Commit();
            }
            catch (Exception ex)
            {
                tx1.Rollback();
                throw ex;
            }
            ITransaction tx2 = session.BeginTransaction();
            IList<Cat> cats = session.CreateQuery("FROM Cat").List<Cat>();
            foreach (Cat c in cats)
            {
                Console.WriteLine(c.name);
            }
            tx2.Commit();
            session.Close();
        }
