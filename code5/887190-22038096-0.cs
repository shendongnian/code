    public IEnumerable<object> Mesh<S,T>(IEnumerable<S> items1, IEnumerable<T> items2){
    	if(!items1.Any())
    		throw new ArgumentNullException("Items1 does not contain elements");
    	if(!items2.Any())
    		throw new ArgumentNullException("Items2 does not contain elements");
    
    	var items1Enumerator = items1.GetEnumerator();
    	var items2Enumerator = items2.GetEnumerator();
    	bool items1Finished = false;
    	bool items2Finished = false;
    	
    	while(!items1Finished && ! items2Finished){
    		if(!items1Enumerator.MoveNext()){
    			items1Enumerator.Dispose();
    			items1Enumerator = items1.GetEnumerator();
    			items1Enumerator.MoveNext();
    			items1Finished = true;
    		}
    		yield return items1Enumerator.Current;
    		
    		if(!items2Enumerator.MoveNext()){
    			items2Enumerator.Dispose();
    			items2Enumerator = items2.GetEnumerator();
    			items2Enumerator.MoveNext();
    			items2Finished = true;
    		}
    		
    		yield return items2Enumerator.Current;
    	}
    	
    	items1Enumerator.Dispose();
    	items2Enumerator.Dispose();
    }
