    public void CheckType(Type type)
    {
    	Dictionary<Type, CheckBox> map = new Dictionary<Type, CheckBox>
    	{
    		{ ACheckBox, Type.A }, 
    		{ BCheckBox, Type.B },
    		{ CCheckBox, Type.C },
    		{ DCheckBox, Type.D },
    		{ ECheckBox, Type.E },
    	}
    
    	foreach(var pair in map)
    	{
    		CheckBox checkBox = pair.Key;
    		Type checkBoxType = pair.Value;
    		if(checkBox.Exists)
    		{
    			bool shouldBeChecked = checkBoxType == type;
    			checkBox.Check(shouldBeChecked);
    		}	
    	}
    }
