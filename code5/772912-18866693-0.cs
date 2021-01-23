    interface IPropertyListOwner<T>
      where T : IProperty
    {
        ObservableCollection<T> Properties { get; }
    }
    
    abstract class AbstractItem<T> : IPropertyListOwner<T>
      where T : IProperty
    {
        public ObservableCollection<T> Properties { get; }
    }
    
    class ConcreteProperty : IProperty {}
    
    class ConcreteItem : AbstractItem<ConcreteProperty>
    {
        public ObservableCollection<ConcreteProperty> Properties { get; }
    }
