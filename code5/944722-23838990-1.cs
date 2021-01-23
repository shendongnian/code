    partial class MyEntity
    {
    	[DataMember]
    	[SimpleProperty]
    	private string DynamicContent
    	{
    		get { return _dynamicContent; }
    		set
    		{
    			if (_dynamicContent != value)
    			{
    				OnPropertyChanging("DynamicContent", value);
    				var previousValue = _dynamicContent;
    				_dynamicContent = value;
    				OnPropertyChanged("DynamicContent", previousValue, value);
    			}
    		}
    	}
    	private string _dynamicContent;
    
        protected override object GetDynamicValue(string propertyName)
        {
            return DynamicPropertyHelper.GetDynamicProperty(DynamicContent, propertyName);
        }
    
        protected override void SetDynamicValue(string propertyName, object value)
        {
            var dynamicContent = DynamicContent;
            DynamicPropertyHelper.SetDynamicProperty(ref dynamicContent, propertyName, value);
            DynamicContent = dynamicContent;
        }
    }
