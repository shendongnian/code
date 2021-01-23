    public class CInternalCollection<T> where T : IComparable
    {
        private T[] m_T_col;
    
        private CInternalCollection() {}
        public CInternalCollection(T[] m_T_col)
        {
            this.m_T_col = m_T_col;
        }
        public void ExternalCollection(ref ICollection<T> ext_col, T para_selection)
        {
            foreach (T value in m_T_col)
            {
                if (value.CompareTo(para_selection) > 0)
                    ext_col.Add(value);
            }
        }
    }
