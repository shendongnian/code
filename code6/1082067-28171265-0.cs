    // get the type of wsSoapBody
    var t = wsSoapBody.GetType();
    
    // loop over all elements of DCSSCustomerUpdate_V3
	foreach(DCSSCustomerUpdate_V3 value in Enum.GetValues(typeof(DCSSCustomerUpdate_V3)))
	{
		if (aMessage[(int)value].ToString().Length != 0)
		{
            // set the value using SetValue
			t.GetProperty(value.ToString()).SetValue(wsSoapBody, aMessage[(int)value].ToString());
		}
	}
