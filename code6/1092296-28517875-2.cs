    public virtual void Write(Object value)
    {
         if (value != null)
         {
              IFormattable f = value as IFormattable;
              if (f != null)
                  Write(f.ToString(null, FormatProvider));
              else
                  Write(value.ToString());
         }
    }
