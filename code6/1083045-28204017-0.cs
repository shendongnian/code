    public class TestClass1Converter : JavaScriptConverter
    {
    	public override IEnumerable<Type> SupportedTypes
        {
            get { return new Type[] { typeof(TestClass1)}; }
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    	{
    		var data = obj as TestClass1;
    		var dic = new Dictionary<string, object>();
    		if(data == null)
    		{
    			return dic;
    		}
    		
    		long val = 0;
    		long.TryParse(data.strlong, out val);
    		dic.Add("strlong", val);
    		return dic;
    	}
    	
    	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
