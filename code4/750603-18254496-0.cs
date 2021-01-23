    public virtual void WriteLine(object value)
    {
    	if (value == null)
    	{
    		this.WriteLine();
    		return;
    	}
    	IFormattable formattable = value as IFormattable;
    	if (formattable != null)
    	{
    		this.WriteLine(formattable.ToString(null, this.FormatProvider));
    		return;
    	}
    	this.WriteLine(value.ToString());
    }
