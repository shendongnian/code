    void bindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
    		{
    			if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
    			{
    				var person = (Person)bindingSource.Current;
    						
    				if ( person.State == State.Unchanged && (e.BindingCompleteState == BindingCompleteState.Success)
    				&& e.Binding.Control.Focused)
    				{
    					person.State = State.Modified;  // using Julie Lerman's repositories technique
    				}
    			}
    		}
    		 
