    class Stack
    {
        int index = 0;
        int[] items = new int[0];
        public Stack(int size)
        {
            items = new int[size]; // initiate items with size
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
