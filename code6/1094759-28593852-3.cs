    private int[] m_buckets;
    private Slot[] m_slots;
    public bool Contains(T item) {
        if (m_buckets != null) {
            int hashCode = InternalGetHashCode(item);
            // see note at "HashSet" level describing why "- 1" appears in for loop
            for (int i = m_buckets[hashCode % m_buckets.Length] - 1; i >= 0; i = m_slots[i].next) {
                if (m_slots[i].hashCode == hashCode && m_comparer.Equals(m_slots[i].value, item)) {
                    return true;
                }
            }
        }
        // either m_buckets is null or wasn't found
        return false;
    }
    private int InternalGetHashCode(T item) {
        if (item == null) {
            return 0;
        } 
        return m_comparer.GetHashCode(item) & Lower31BitMask;
    }
    internal struct Slot {
        internal int hashCode;      // Lower 31 bits of hash code, -1 if unused
        internal T value;
        internal int next;          // Index of next entry, -1 if last
    }
