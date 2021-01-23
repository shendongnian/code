    public class CompositeList<T> : IList<T>
    {
        private IList<IList<T>> lists;
        public CompositeList(IList<IList<T>> lists)
        {
            this.lists = lists;
        }
        public CompositeList(params IList<T>[] lists)
        {
            this.lists = lists;
        }
        public int IndexOf(T item)
        {
            int globalIndex = 0;
            foreach (var list in lists)
            {
                var localIndex = list.IndexOf(item);
                if (localIndex >= 0)
                    return globalIndex + localIndex;
                else
                    globalIndex += list.Count;
            }
            return -1;
        }
        public void Insert(int index, T item)
        {
            //note that there is an ambiguity over where items should be inserted
            //when they are on the border of a set of lists.
            foreach (var list in lists)
            {
                //use greater than or equal instead of just greater than to have the inserted item 
                //go in the later of the two lists in ambiguous situations, 
                //rather than the former.
                if (index > list.Count)
                    index -= list.Count;
                else
                {
                    list.Insert(index, item);
                    return;
                }
            }
            //TODO deal with having no lists in `lists`
            //TODO deal with having only empty lists in `lists`
            throw new IndexOutOfRangeException();
        }
        public void RemoveAt(int index)
        {
            foreach (var list in lists)
            {
                if (index > lists.Count)
                    index -= list.Count;
                else
                    list.RemoveAt(index);
            }
            throw new IndexOutOfRangeException();
        }
        public T this[int index]
        {
            get
            {
                foreach (var list in lists)
                {
                    if (index > lists.Count)
                        index -= list.Count;
                    else
                        return list[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                foreach (var list in lists)
                {
                    if (index > lists.Count)
                        index -= list.Count;
                    else
                        list[index] = value;
                }
                throw new IndexOutOfRangeException();
            }
        }
        public void Add(T item)
        {
            if (!lists.Any())
                lists.Add(new List<T>());
            lists[lists.Count - 1].Add(item);
        }
        public void Clear()
        {
            foreach (var list in lists)
                list.Clear();
        }
        public bool Contains(T item)
        {
            return lists.Any(list => list.Contains(item));
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex - Count < 0)
                throw new ArgumentException("The array is not large enough.");
            int iterations = Math.Min(array.Length, Count);
            for (int i = arrayIndex; i < iterations; i++)
                array[i] = this[i];
        }
        public int Count
        {
            get { return lists.Sum(list => list.Count); }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            foreach (var list in lists)
            {
                if (list.Remove(item))
                    return true;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return lists.SelectMany(x => x).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
