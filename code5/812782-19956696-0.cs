    public class UniqueValueQueue<T> : Queue<T>
    {
        private readonly HashSet<T> pastValues = new HashSet<T>();
        public new void Enqueue(T item)
        {
            if (!pastValues.Contains(item))
            {
                pastValues.Add(item);
                base.Enqueue(item);
            }
        }
    }
