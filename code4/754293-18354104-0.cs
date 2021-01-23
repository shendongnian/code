    public struct sBool {
      private Boolean m_Value;
    
      public static readonly sBool Enabled = new sBool(true);
      public static readonly sBool Disabled = new sBool(false);
    
      ...
    
      private sBool(Boolean value) {
        m_Value = value;
      }
    
      ...
    
      public override bool Equals(object obj) {
        if (!(obj is sBool))
          return false;
    
        sBool other = (sBool) obj;
    
        return other.m_Value == m_Value;
      }
    
      public override int GetHashCode() {
        return m_Value ? 1 : 0;
      }
    
      ...
    
      public Boolean ToBoolean() {
        return m_Value;
      }
    
      public static implicit operator Boolean(sBool value) {
        return value.m_Value; 
      }  
    }
    
    sBool e = sBool.Enabled;
    sBool f = sBool.Disabled;
    
    if (e || f == sBool.Disabled) {
      ...
    }
