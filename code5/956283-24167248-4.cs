    public class CInternalCollection<T> where T : IComparable
    {
        private T[] m_T_col;
    
        public CInternalCollection()
        {
            m_T_col = new T[6];
            // TODO - Add values depending on the type of T
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
