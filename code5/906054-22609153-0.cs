    public class AppAnnieImport : IEnumerator<AppLines>, IEnumerable<AppLines>
    {
        public int code { get; set; }
        public DateTime end_date { get; set; }
        public string vertical { get; set; }
        public string granularity { get; set; }
        public string device { get; set; }
        public List<AppLines> AppLine { get; set; }
        private int position;
    
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator<AppLines> GetEnumerator()
        {
            return (IEnumerator<AppLines>)this;
        }
    
    	IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<AppLines>)this;
        }
    
        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < AppLine.Count);
        }
    
        //IEnumerable
        public void Reset()
        { position = 0; }
    
        //IEnumerable
        object IEnumerator.Current
        {
            get { return (AppLine.ToArray())[position] ; }
        }
    	
    	public AppLines Current
        {
            get { return (AppLine.ToArray())[position] ; }
        }
    
    	public void Dispose()
    	{
    		// do something or not
    	}
    }
