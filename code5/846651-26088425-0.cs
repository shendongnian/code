    public class TypedSet<AbstractType> : KeyedCollection<Type, AbstractType> {
        protected override Type GetKeyForItem(AbstractType item) {
            return item.GetType();
        }
    }
