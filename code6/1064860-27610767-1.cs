    public class UserControlFactory : IUserControlFactory
    {
        public T Create<T>() where T : UserControl
        {
            return (T) ObjectFactory.GetInstance(typeof(T));
        }
    }
