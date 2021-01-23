	internal sealed class XmlReaderWrapperWithPath : IDisposable
	{
		private const string DefaultPathSeparator = ".";
		private readonly Stack<string> _previousNames = new Stack<string>();
		private readonly XmlReader _reader;
		private readonly bool _ownsReader;
		public XmlReaderWrapperWithPath(XmlReader reader, bool ownsReader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			_ownsReader = ownsReader;
			_reader = reader;
			PathSeparator = DefaultPathSeparator;
		}
		public bool Read()
		{
			var lastDepth = Depth;
			var lastName = Name;
			if (!_reader.Read())
			{
				return false;
			}
			if (Depth > lastDepth)
			{
				_previousNames.Push(lastName);
			}
			else if (Depth < lastDepth)
			{
				_previousNames.Pop();
			}
			return true;
		}
		public string Name
		{
			get
			{
				return _reader.Name;
			}
		}
		public string Value
		{
			get
			{
				return _reader.Value;
			}
		}
		private int Depth
		{
			get
			{
				return _reader.Depth;
			}
		}
		public string Path
		{
			get
			{
				return string.Join(PathSeparator, _previousNames.Reverse());
			}
		}
		public string PathSeparator { get; set; }
		#region IDisposable
		public void Dispose()
		{
			if (_ownsReader)
			{
				_reader.Dispose();
			}
		} 
		#endregion
	}
