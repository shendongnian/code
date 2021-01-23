    // type of the enum; pass in as parameter
    var enumType = typeof(DCSSCustomerUpdate_V3)
    // get the type of wsSoapBody
    var t = wsSoapBody.GetType();
    
    // loop over all elements of DCSSCustomerUpdate_V3
	foreach(var value in Enum.GetValues(enumType))
	{
		if (aMessage[(int)value].ToString().Length != 0)
		{
            // set the value using SetValue
			t.GetProperty(value.ToString()).SetValue(wsSoapBody, aMessage[(int)value].ToString());
		}
	}
