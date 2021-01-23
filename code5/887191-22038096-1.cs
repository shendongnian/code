    public IEnumerable<object> Mesh<S,T>(IEnumerable<S> items1, IEnumerable<T> items2){
    	bool items1Empty;
    	bool items2Empty;
    	bool items1Finished = items1Empty = ValidateParameter(items1, "items1");
    	bool items2Finished = items2Empty = ValidateParameter(items2, "items2");
    
    	using(var items1Enumerator = items1.GetEnumerator()){
    		using(var items2Enumerator = items2.GetEnumerator()){
    			while(true){
    				MoveNext(items1Enumerator, ref items1Finished);
    				MoveNext(items2Enumerator, ref items2Finished);
    				
    				if(items1Finished && items2Finished)
    					break;
    				
    				if(!items1Empty)
    					yield return items1Enumerator.Current;
    								
    				if(!items2Empty)
    					yield return items2Enumerator.Current;
    			}
    		}
    	}
    }
    
    private bool ValidateParameter<T>(IEnumerable<T> parameter, string parameterName){
    	if(parameter == null)
    		throw new ArgumentNullException(parameterName);
    	return !parameter.Any();
    }
    
    private void MoveNext(IEnumerator enumerator, ref bool finished){
    	if(!enumerator.MoveNext()){
    		enumerator.Reset();
    		enumerator.MoveNext();
    		finished = true;
    	}
    }
