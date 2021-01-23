		public T Filter<T>(string target, string actual, T value)
		{
			return _match(target, actual) ? value : default(T);
		}
		public bool Filter(string target, string actual, bool value) 
		{ 
			return _match(target, actual) ? value : !value;
		}
		private bool _match(string target, string actual)
		{ 
			return !string.IsNullOrEmpty(target)
				&& !string.IsNullOrEmpty(actual)
				&& string.Equals(target, actual, StringComparison.CurrentCultureIgnoreCase);
		}
