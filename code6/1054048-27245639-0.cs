	public class Application
	{
		[Column("DatabaseColumnName")]
		public long? StartScriptID { get; set; }
		[ForeignKey("StartScriptID")]
		public virtual Script StartScript { get; set; }
	}
