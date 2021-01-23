    public class MyFormattingCollection : IList<string>
    {
        private IList<decimal> _values;
        private IList<string> _formattedValues;
        public MyFormattingCollection(IList<DateTime> values)
        {
            _values = values;
            _formattedValues = new string[_values.Count];
        }
        public string this[int index]
        {
            get
            {
                var result = _formattedValues[index];
                if (result == null)
                {
                    result = FormatTheWayIWant(_values[index]);
                    _formattedValues[index] = result;
                }
                return result;
           }
           set
           {
               // Throw: it's a readonly collection
           }
        }
        // Boilerplate implementation of readonly IList<string> ...
    }
