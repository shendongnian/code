    public class CInternalCollection
    {
        public static void ExternalCollectionTryOne(ref ICollection<int> ext_col, int para_selection = 0)
        {
            foreach (int int_value in m_int_col)
            {
                if (int_value > para_selection)
                    ext_col.Add(int_value);
            }
        }
        public static void ExternalCollectionTryTwo(ref ICollection ext_col, int para_selection = 0)
        {
            foreach (int int_value in m_int_col)
            {
                if (int_value > para_selection)
                    ext_col.Add(int_value);
            }
        }
        static int[] m_int_col = { 0, -1, -3, 5, 7, -8 };
    }
