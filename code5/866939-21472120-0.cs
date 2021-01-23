    class Stack
    {
        int index = 0;
        int[] items;
        public Stack()
        {
            items = ...; // initiate items
        }
        public void Push(int p)
        {
            items[index] = p;
            index++;
        }
        public int Pop()
        {
            index--;
            return items[index];
        }
        internal int IndexState()
        {
            return index;
        }
    }
