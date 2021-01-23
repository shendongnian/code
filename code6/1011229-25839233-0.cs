    class Transform : IEnumerable<Transform>
    {
    	public IEnumerator<Transform> GetEnumerator()
    	{
    		//traverse child tree yielding items
            Transform transform; // = somevalue;
    		yield return transform;
    	}
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    	
    }
