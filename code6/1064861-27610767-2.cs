    public class UserControlFactory : IUserControlFactory
    {
        public T Create<T>() where T : UserControl
        {
            return ObjectFactory.GetInstance<T>();
        }
    }
