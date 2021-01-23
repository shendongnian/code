    public class CInternalCollection
    {
        public static void ExternalCollectionTryOne<T<int>>(ref T<int> ext_col, int para_selection = 0)
        {
            if(ext_col is ICollection)
            {
                ICollection collection = (ICollection)ext_col;
                foreach (int int_value in m_int_col)
                {
                    if (int_value > para_selection)
                        collection.Add(int_value);
                }
            }
        }
        public static void ExternalCollectionTryTwo<T>(ref T ext_col, int para_selection = 0)
        {
            if(ext_col is ICollection)
            {
                ICollection collection = (ICollection)ext_col;
                foreach (int int_value in m_int_col)
                {
                    if (int_value > para_selection)
                        collection.Add(int_value);
                }
            }
        }
        static int[] m_int_col = { 0, -1, -3, 5, 7, -8 };
    }
