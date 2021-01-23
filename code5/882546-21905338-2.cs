    public class CustomDictionary : IEnumerable
    {
    	private Dictionary<int, Tuple<DependencyObject, DependencyProperty>> properties = new Dictionary<int, Tuple<DependencyObject, DependencyProperty>>();
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		foreach (var item in properties)
    		{
    			yield return  new KeyValuePair<int, object>(item.Key, item.Value.Item1.GetValue(item.Value.Item2));
    		}
    	}
    
    	public void Add(int index, DependencyObject obj, DependencyProperty property)
    	{
    		properties.Add(index, new Tuple<DependencyObject, DependencyProperty>(obj, property));
    	}
    
    	public object this[int index]
    	{
    		get
    		{
    			return properties[index].Item1.GetValue(properties[index].Item2);
    		}
    		set
    		{
    			properties[index].Item1.SetCurrentValue(properties[index].Item2, value);
    		}
    	}
    }
