    public abstract class AbstractQueryObject<TResult> : IQueryObject<TResult>
    {
        protected ISession Session;
        public void Configure(object parameter)
        {
            if (!(parameter is ISession))
                throw new ArgumentException(String.Format("Argument of wrong type. Expecting {0} but got {1}.", typeof(ISession), parameter != null ? parameter.GetType().ToString() : "null"), "parameter");
            this.Session = parameter as ISession;
        }
        public abstract TResult GetResult();
    }
    public interface IQueryObject<TResult>
    {
        void Configure(object parameter);
        TResult GetResult();
    }
