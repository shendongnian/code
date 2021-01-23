    public abstract class AbstractItem<T> : IPropertyListOwner where T:IProperty
    {
        public ObservableCollection<T> Properties { get; private set; }
    }
    
    public class ConcreteItem : AbstractItem<ConcreteProperty>
    {
       
    }
