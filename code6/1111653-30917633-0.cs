    private class PropertyInfoData
    {
	    public string TypeName
	    {
		    get;
		    set;
	    }
	
	    public string PropertyName
	    {
		    get;
		    set;
	    }
	
	    public static PropertyInfoData FromProperty(PropertyInfo p)
	    {
		    return new PropertyInfoData()
		    {
			    TypeName = p.DeclaringType.AssemblyQualifiedName,
			    PropertyName = p.Name,
		    };
	    }
	
	    public PropertyInfo ToProperty()
	    {
		    return Type.GetType(this.TypeName).GetProperty(this.PropertyName);
	    }
    }
