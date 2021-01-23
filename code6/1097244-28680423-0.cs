    class StackOverflowExample
    {
        private MapThing _map;
        private IDictionary<string, Action> _mapActions;
        public StackOverflowExample()
        {
            _map = new MapThing();
            _mapActions = new Dictionary<string, Action>
            {
                { "orange", _map.functionOrange },
                { "peach", _map.functionPeach },
                ...
            }
        }
        public void Fruit(string name)
        {
            // Now, instead of the giant switch statement...
            if (_mapActions.ContainsKey(name))
                _mapActions[name].Invoke();
            // Throw an exception if name not in dictionary
        }
    }
