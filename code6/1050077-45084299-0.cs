    [Serializable]
    public class SerializableQueue : Queue<MyObject>
    {
        public MyObject this[int index]
        {
            get
            {
                int count = 0;
                foreach (MyObject o in this)
                {
                    if (count == index)
                        return o;
                    count++;
                }
                return null;
            }
        }
        public void Add(MyObject r)
        {
            Enqueue(r);   
        }
    }
