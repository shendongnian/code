    // get a PropertyDescriptor using case-insensitive lookup
    PropertyDescriptor pd = GetPropertiesFromCache(container).Find(propName, true);
    if (pd != null) {
    	prop = pd.GetValue(container);
    }
    else {
    	throw new HttpException(SR.GetString(SR.DataBinder_Prop_Not_Found, container.GetType().FullName, propName));
    }
