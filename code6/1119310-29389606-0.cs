    public class CustomerManager
    {
        private Lazy<DAL.CustomerManager> _lazyDalManager= new Lazy<CustomerManager>(()=>new DAL.CustomerManager());
        protected DAL.CustomerManager DalCustomerManager
        {
            get { return _lazyDalManager.Value; }
        }
    }
