    public override Type DeclaringType 
    { 
        get 
        { 
            return m_reflectedTypeCache.IsGlobal ? null : m_declaringType; 
        }
    }
