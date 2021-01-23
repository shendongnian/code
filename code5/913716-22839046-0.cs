    public class Meeting<T> where T : Human, new()
    {
        private T[] visitors;
        public T[] Visitors
        {
            get { return visitors; }
            set { visitors = value; }
        }
        public Meeting(int number)
        {
            visitors = new T[number];
            for (int i = 0; i < number; i++)
            {
                visitors[i] = new T();
            }
        }
    }
