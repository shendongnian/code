    public class ListHanterare<T> 
    {
        private List<T> lista; // This is the list
        private int count;
        public ListHanterare()
        {
            lista = new List<T>();
        }
        [XmlElement("Item")]
        public T[] SerializableList
        {
            get
            {
                return (lista == null ? new T [0] : lista.ToArray());
            }
            set
            {
                if (lista == null)
                    lista = new List<T>();
                lista.Clear();
                lista.AddRange(value ?? Enumerable.Empty<T>());
                count = lista.Count;
            }
        }
    }
