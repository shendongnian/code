    public class AClass
    {
        private Dictionary<string, object> _originalVals =
            new Dictionary<string, object>();
        private string _aProperty;
        public string AProperty
        {
            get { return _aProperty; }
            set
            {
                SetModifiedProperty("AProperty", _aProperty);
                _aProperty = value;
            }
        }
        private void SetModifiedProperty(string propertyName, object val)
        {
            if (_originalVals.ContainsKey(propertyName)) { return; }
            _originalVals.Add(propertyName, val);
        }
    }
