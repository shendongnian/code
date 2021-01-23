    private class FilterCountryConverter : JavaScriptConverter
    {
       public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
       {
           throw new NotImplementedException();
       }
    
    	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
       {
           var output = new Dictionary<string, object>();
           FilterCountry fc = obj as FilterCountry;
    	   output.Add( fc.Country, fc.Count );
           return output;
       }
    
       public override IEnumerable<Type> SupportedTypes
       {
           get { return new List<Type>(new List<Type>(new Type[] { typeof(FilterCountry) }));  }
       }
    }
