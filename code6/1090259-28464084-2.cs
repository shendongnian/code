    public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
    {
        // set the value using the NullSafeSet implementation for string from NHibernateUtil
        if (value == null)
        {
            global::NHibernate.NHibernateUtil.String.NullSafeSet(cmd, null, index);
            return;
        }
        
        /* Allow for the possibility of a string */
        string valueToSet = null;
        
        if (value.GetType() == typeof(string))
        {
            valueToSet = (string)value;
        }
        else if (value.GetType() == typeof(SpecialType))
        {
            valueToSet = ((SpecialType)value).Code;
        }
        global::NHibernate.NHibernateUtil.String.NullSafeSet(cmd, valueToSet, index);
    }
