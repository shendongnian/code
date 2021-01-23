    public class Foo
    {
        private List<int> _l;
    	
    	public IList<int> L { get { return this._l.AsReadOnly(); } }
    
        public Foo(List<int> newList)
        {
            this._l = new List<int>(newList);
        }
    }
