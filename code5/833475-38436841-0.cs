    Dictionary<string, string> _description = new Dictionary<string, string>();
    public float getDescription(string value)
    {
         string lookup;
         if (_description.TryGetValue (id, out lookup)) {
            return lookup;
         }
            			
         _description[id] = value;
         return lookup;
    }
 
