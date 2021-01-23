        var frameWorkElement = e.OriginalSource as FrameworkElement;
    	while (frameWorkElement != null)
    	{
    		Type genericbaseType = GetGenericBaseTypeOfType(typeof(UpDownBase<>), frameWorkElement.GetType()); // JaredPar StackOverfLow code
    		{
    			if (genericbaseType != null)
    			{
    				FieldInfo fi = frameWorkElement.GetType().GetField("ValueProperty", BindingFlags.GetField | BindingFlags.Default | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.SetField);
    				if (fi != null)
    				{
    					var dp = fi.GetValue(null) as DependencyProperty;
    					if (dp != null)
    					{
    						be = frameWorkElement.GetBindingExpression(dp); // Null if done like the other answer.
    						if (be != null)
    						{
    							be.UpdateSource();
    						}
    					}
    				}
    				break;
    			}
    		}
    
    		frameWorkElement = VisualTreeHelper.GetParent(frameWorkElement) as FrameworkElement;
