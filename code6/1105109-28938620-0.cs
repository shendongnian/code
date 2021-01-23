    public class NHibernateBaseRepository : IDisposable
    {
        private ISession _session;
    
        public NHibernateBaseRepository ()
        {
            _session = m_SessionFactory.OpenSession(); //session factory should be created once per application lifetime, not per instance.
        }
    
        public void Dispose()
        {
            _session.Dispose();
        }
        public T GetById<T>(long id)
        {
            return _session.Get<T>(id);	
        }
    }
