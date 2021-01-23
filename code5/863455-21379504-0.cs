    public class DroppingStack<T> : IEnumerable<T>
    {
        T[] array;
        int cap;
        int begin;
        int end;
        public DroppingStack (int capacity)
	    {
            cap = capacity+1;
            array = new T[cap];
            begin = 0;
            end = 0;
	    }
        public T pop()
        {
            if (begin == end) throw new Exception("No item");
            begin--;
            if (begin < 0)
                begin += cap;
            return array[begin];
        }
        public void push(T value)
        {
            array[begin] = value;
            begin = (begin+1)%cap;
            if (begin == end)
                end = (end + 1) % cap;
        }
        public IEnumerator<T> GetEnumerator()
        {
            int i = begin-1;
            while (i != end-1)
            {
                yield return array[i];
                i--;
                if (i < 0)
                    i += cap;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
