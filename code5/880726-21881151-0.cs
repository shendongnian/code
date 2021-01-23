    protected override Size MeasureOverride(Size availableSize)
    {
    	double totalWidth = availableSize.Width;
    	double absoluteWidth = 0.0;
    
    	DataGridColumn star = null;
    	foreach (var col in Columns)
    	{
    		if (col.Width.IsAbsolute)
    		{
    			absoluteWidth += col.Width.Value;
    			col.MinWidth = col.Width.Value;
    		}
    		else if (col.Width.IsAuto)
    		{
    			absoluteWidth += col.Width.DisplayValue;
    		}
    		else if (col.Width.IsStar)
    		{
    			if (null == star)
    			{
    				star = col;
    			}
    			else
    			{
    				// This method only handles one star column
    				star = null;
    				break;
    			}
    		}
    	}
    
    	if (null != star)
    	{
    		double diff = totalWidth - absoluteWidth - 4.0;
    		if (diff > 0.0)
    			star.MinWidth = diff;
    		else
    			star.MinWidth = 10.0;
    	}
    
    	return base.MeasureOverride(availableSize);
    }
