    public abstract class BaseProvider<T>
    {
        public abstract void NewItem(T type);
    }
    
    public class TestProvider : BaseProvider<MyEnum>
    {
        public override void NewItem(MyEnum type)
        {
        }
    }
