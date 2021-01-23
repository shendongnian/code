    public class SomeClass
    {
        private string _displayValue;
        public string Value {get;set;}
        public string DisplayValue
        {
            get 
            {
               if (string.IsNullOrEmpty(_displayValue))
               {
                   if (fieldType == "ImageUri")
                   {
                       FileInfo file = new FileInfo(Value);
                       return Path.Combine(file.Directory.Name, fileName);
                   }
                   else
                   {
                       return Value;
                   }
                }
                else
                {
                    return _displayValue;
                }
           }
           set {_displayValue = value;}
        }
    }
