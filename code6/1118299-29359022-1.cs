        public class UtcTime
        {
            public virtual long Id { get; set; }
            public virtual DateTime DateSaved { get; set; }
        }
    
        public class UtcTimeClassMap : ClassMap<UtcTime>
        {
            public UtcTimeClassMap()
            {
                Id(t => t.Id).GeneratedBy.Native();
                Map(t => t.DateSaved ).CustomType<UtcDateTimeType>();
            }
        }
    
        [Test]
        public void SimpleTest()
        {
            long id = 0;
            ISession session = _sessionFactory.OpenSession();
            using (ITransaction tran = session.BeginTransaction())
            {
                UtcTime utc = new UtcTime();
                utc.DateSaved = DateTime.Now;
                session.Save(utc);
                tran.Commit();
                Console.WriteLine(utc.DateSaved.Ticks + "_" + utc.DateSaved.Kind + "_" + utc.Date.ToString());
                id = utc.Id;
            }
            session.Flush();
            session.Clear();
            session = _sessionFactory.OpenSession();
            var retrieved = session.Get<UtcTime>(id);
            Console.WriteLine(retrieved.DateSaved.Ticks + "_" + retrieved.Date.Kind + "_" + retrieved.DateSaved.ToString());
        }
