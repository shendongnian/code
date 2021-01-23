    public class Testing
    {
        private List<string> _listOfStrings;
        public IEnumerable<string> MyStrings
        {
            get
            {
                foreach (var s in _myStrings)
                    yield return s;
            }
        }
    
        public Testing()
        {
            _listOfStrings = new List<string>();
        }
    }
