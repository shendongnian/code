    public class Set<T> : HashSet<T>
    {
        private event ChangedEventHandler Added;
        public bool Add(T item)
        {
            bool answer = base.Add(item);
            OnAdded();
            return answer;
        }
        private void OnAdded()
        {
            if (Added == null)
                return;
            Added();
        }
    }
