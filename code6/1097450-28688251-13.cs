    public interface IBusinessManager<T>
    {
        void ManagerStuff(T entityToManage);
    }
    public class BusinessManager<T> : IBusinessManager<T> where T : IEntity
    {
        private readonly IBusinessValidator<T> validator;
        public BusinessManager(IBusinessValidator<T> validator)
        {
            this.validator = validator;
        }
        public void ManagerStuff(T entityToManage)
        {
            // stuff.
        }
    }
