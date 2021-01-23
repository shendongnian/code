	class TraceWriter : Newtonsoft.Json.Serialization.ITraceWriter
	{
		public TraceLevel LevelFilter {
			get {
				return TraceLevel.Error;
			}
		}
		public void Trace(TraceLevel level, string message, Exception ex)
		{
			Console.WriteLine("JSON {0} {1}: {2}", level, message, ex);
		}
	}
