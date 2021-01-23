    public class COntainerSelector : StyleSelector
    {
    	public Style Answered { get; set; }
    	public Style Default { get; set; }
    	protected override Style SelectStyleCore(object item, DependencyObject container)
    	{
    		var data = item as userData;
            //If data is null or it un answered we use default container (have tilt effect)
    		if (data==null || !data.answered) return Default;
    		return Answered;
            return base.SelectStyleCore(item, container);
    	}
    }
