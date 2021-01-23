    public class ListManager<T>
    {
        private List<T> m_list;
        public ListManager()
        {
            m_list = new List<T>();
        }
        public int Count
        {
            get {return m_list.Count; }
        }
        public void Add(T aType)
        {
            m_list.add (aType);
        }
        public bool DeleteAt(int anIndex)
        {
            m_list.DeleteAt (anIndex);
        }
        public string[] ToStringArray()
        {
           
        }
        public List<string> ToStringList()
        {
            
        }
        public bool CheckIndex(int index)
        {
        }
        }
    }
