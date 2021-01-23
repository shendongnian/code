    public class ObjectMap
    {
        public object[] ActivatedObjects { get; private set; }
        public ObjectMap(params object[][] itemsToMap)
        {
            ActivatedObjects = itemsToMap.Select(ActivateItem).ToArray();
        }
        private object ActivateItem(object[] itemToActivate)
        {
            return Activator.CreateInstance((Type)itemToActivate[0], itemToActivate.Skip(1).ToArray());
        }
    }
