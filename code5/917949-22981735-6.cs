    public class UseCase
    {
        public void Method()
        {
            //when instantiating a session pass the interceptor to it.
            //then, also pass this sniffer to the query objects you create.
            //make the query objects listeners.
            //when the query object is to be executed (start of the get result method)
            //call the set active listener method on the sniff notifier given to the q.o.
            //in the on prepare statement method of the q.o. do whatever with the sql.
            SqlSniffer myInterceptor = new SqlSniffer();
            var session = this.SessionFactory.OpenSession(myInterceptor);
        }
    }
    
    
    public interface ISqlSniffListener
    {
        void OnPrepareStatement(string sql);
    }
    
    public interface ISqlSniffNotifier
    {
        void SetActiveListener(ISqlSniffListener listener);
    }
    
    public class SqlSniffer : EmptyInterceptor, ISqlSniffNotifier
    {
        private ISqlSniffListener ActiveListener;
    
        public void SetActiveListener(ISqlSniffListener listener)
        {
            this.ActiveListener = listener;
        }
        
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            if (this.ActiveListener != null)
                this.ActiveListener.OnPrepareStatement(sql.ToString());
    
            return base.OnPrepareStatement(sql);
        }
    }
