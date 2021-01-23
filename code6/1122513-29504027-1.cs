    public class FormsCollection : IEnumerable
    {
	    private Collection c = new Collection();
	    public Form Item {
		    get { return c.Item(index); }
	    }
	    public void Add(Form frm)
	    {
		    c.Add(frm);
	    }
	    public virtual IEnumerator GetEnumerator()
	    {
		    return c.GetEnumerator;
	    }
	    public void Remove(Form frm)
	    {
		    int itemCount = 0;
		    for (itemCount = 1; itemCount <= c.Count; itemCount++) {
			    if (object.ReferenceEquals(frm, c.Item(itemCount))) {
				    c.Remove(itemCount);
				    break;
			    }
		    }
    	}
    }
