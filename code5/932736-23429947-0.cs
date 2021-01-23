    	Dictionary<string, Action<object>> _methodDictionary = new Dictionary<string, Action<object>>();
		public void Report(IEnumerable<Action<object>> actions)
        {
            foreach (var action in actions)
            {
				// you need to get your name somehow.
				_methodDictionary.Add(GetName, action);
            }
		}
		public void callMethod(string actionName, object itemToPass)
		{
			if(_methodDictionary.ContainsKey(actionName))
				_methodDictionary[actionName].Invoke(itemToPass);
		}
