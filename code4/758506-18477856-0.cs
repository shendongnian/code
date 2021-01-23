        public class MyList<T> : IEnumerable<T>
        {
            T[] list = new T[32];
            int listLength;
            public void Add(T item)
            {
                if (listLength + 1 > list.Length)
                {
                    T[] temp = new T[list.Length * 2];
                    Array.Copy(list, temp, list.Length);
                    list = temp;
                }
                list[listLength] = item;
                listLength++;
            }
            public void Remove(T item)
            {
                for (int i = 0; i < list.Length; i++)
                    if (list[i].Equals(item))
                    {
                        RemoveAt(i);
                        return;
                    }
            }
            public void RemoveAt(int index)
            {
                if (index < 0 || index >= listLength)
                {
                    throw new ArgumentException("'index' must be between 0 and list length.");
                }
                if (index == listLength - 1)
                {
                    list[index] = default(T);
                    listLength = index;
                    return;
                }
                // need to shift the list
                Array.Copy(list, index + 1, list, index, listLength - index + 1);
                listLength--;
                list[listLength] = default(T);
            }
            public IEnumerator<T> GetEnumerator()
            {                
                for (int i = 0; i < listLength; i++)
                {
                    yield return list[i];
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
