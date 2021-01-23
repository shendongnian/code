    public class UserControlFactory:IUserControlFactory
    {
        public T Create<T>(MyClass object1) where T : UserControl
        {
            return (T) ObjectFactory.With("object1").EqualTo(object1).GetInstance(typeof(T));
        }
    }
