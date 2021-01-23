    public interface IView
    {
        public string CustomerName { get; set; }
    }
    public interface ICustomer
    {
        string CustomerName { get; set; }
    }
    public interface IModel
    {
        void Save(ICustomer entity);
        void Update(ICustomer entity);
        ICustomer Create();
    }
    public class Customer : ICustomer
    {
        public string CustomerName {get;set;}
    }
    public class MyModel : IModel
    {
        public void Save(ICustomer entity)
        {
            //Do something here..
        }
        public void Update(ICustomer entity)
        {
            //Do something here..
        }
        public ICustomer Create()
        {
            return new Customer();
        }
    }
    public class Presenter
    {
        private IView _view;
        private ICustomer _entity;
        private IModel _model = new MyModel();
        public Presenter(IView view)
        {
            _view = view;
            _model = new MyModel();
            _entity = _model.Create();
            _view.CustomerName = _entity.CustomerName;
        }
        public void Save()
        {
            _model.Save(_entity);
        }
        public void Cancel()
        {
            _entity = _model.Create();
        }
        public void UpdateModel(ICustomer customer)
        {
            _model.Update(customer);
            _view.CustomerName = customer.CustomerName;
        }
    }
