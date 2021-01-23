    public class ChArray {
        // (as you have it)
        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to ChArray return false:
            ChArray p = obj as ChArray;
            if ((object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return m_str == p.m_str;
        }
    
        public bool Equals(ChArrayp)
        {
            // Return true if the fields match:
            return m_str == p.m_str;
        }
    
        public override int GetHashCode()
        {
            return m_str.GetHashCode();
        }
    }
