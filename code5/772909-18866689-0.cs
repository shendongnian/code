    public abstract class AbstractItem<T> : IPropertyListOwner where T:IProperty
    {
        public ObservableCollection<T> Properties { get; }
    }
    
    public class ConcreteItem : AbstractItem<ConcreteProperty>
    {
       
    }
