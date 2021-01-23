    public class SqlGuid
        : System.IComparable
        , System.IComparable<SqlGuid>
        , System.Collections.Generic.IComparer<SqlGuid>
        , System.IEquatable<SqlGuid>
    {
        private const int NUM_BYTES_IN_GUID = 16;
        // Comparison orders.
        private static readonly int[] m_byteOrder = new int[16] // 16 Bytes = 128 Bit 
        {10, 11, 12, 13, 14, 15, 8, 9, 6, 7, 4, 5, 0, 1, 2, 3};
        private byte[] m_bytes; // the SqlGuid is null if m_value is null
        public SqlGuid(byte[] guidBytes)
        {
            if (guidBytes == null || guidBytes.Length != NUM_BYTES_IN_GUID)
                throw new System.ArgumentException("Invalid array size");
            m_bytes = new byte[NUM_BYTES_IN_GUID];
            guidBytes.CopyTo(m_bytes, 0);
        }
        public SqlGuid(System.Guid g)
        {
            m_bytes = g.ToByteArray();
        }
        public byte[] ToByteArray()
        {
            byte[] ret = new byte[NUM_BYTES_IN_GUID];
            m_bytes.CopyTo(ret, 0);
            return ret;
        }
        int CompareTo(object obj)
        {
            if (obj == null)
                return 1; // https://msdn.microsoft.com/en-us/library/system.icomparable.compareto(v=vs.110).aspx
            System.Type t = obj.GetType();
            if (object.ReferenceEquals(t, typeof(System.DBNull)))
                return 1;
            if (object.ReferenceEquals(t, typeof(SqlGuid)))
            {
                SqlGuid ui = (SqlGuid)obj;
                return this.Compare(this, ui);
            } // End if (object.ReferenceEquals(t, typeof(UInt128)))
            return 1;
        } // End Function CompareTo(object obj)
        int System.IComparable.CompareTo(object obj)
        {
            return this.CompareTo(obj);
        }
        int CompareTo(SqlGuid other)
        {
            return this.Compare(this, other);
        }
        int System.IComparable<SqlGuid>.CompareTo(SqlGuid other)
        {
            return this.Compare(this, other);
        }
        
        enum EComparison : int
        {
            LT = -1, // itemA precedes itemB in the sort order.
            EQ = 0, // itemA occurs in the same position as itemB in the sort order.
            GT = 1 // itemA follows itemB in the sort order.
        }
        public int Compare(SqlGuid x, SqlGuid y)
        {
            byte byte1, byte2;
            //Swap to the correct order to be compared
            for (int i = 0; i < NUM_BYTES_IN_GUID; i++)
            {
                byte1 = x.m_bytes[m_byteOrder[i]];
                byte2 = y.m_bytes[m_byteOrder[i]];
                if (byte1 != byte2)
                    return (byte1 < byte2) ?  (int) EComparison.LT : (int) EComparison.GT;
            } // Next i 
            return (int) EComparison.EQ;
        }
        
        int System.Collections.Generic.IComparer<SqlGuid>.Compare(SqlGuid x, SqlGuid y)
        {
            return this.Compare(x, y);
        }
        public bool Equals(SqlGuid other)
        {
            return Compare(this, other) == 0;
        }
        bool System.IEquatable<SqlGuid>.Equals(SqlGuid other)
        {
            return this.Equals(other);
        }
    }
