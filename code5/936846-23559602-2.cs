    public class AssignmentList<T> : IEnumerable<Tuple<LambdaExpression, object>>
    {
        private readonly List<Tuple<LambdaExpression, object>> _list 
                = new List<Tuple<LambdaExpression, object>>();
    
        public void Add<TProperty>(Expression<Func<T, TProperty>> selector, TProperty value)
        {
    	    _list.Add(Tuple.Create<LambdaExpression, object>(selector, value));  	  
    	}
    	  
        public IEnumerator<Tuple<LambdaExpression, object>> GetEnumerator()
        {
    	    return _list.GetEnumerator();
        }
    	  
    	IEnumerator IEnumerable.GetEnumerator()
    	{ 
    	    return GetEnumerator();
    	}
    }
