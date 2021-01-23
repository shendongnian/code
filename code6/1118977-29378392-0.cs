    public class LastSyncTime
	{
		public int id { get; set; }
		public string SyncTime { get; set; }
		[XmlIgnore]
		public DateTime Time  // This is used to convert DateTime to a string
		{
			get
			{
				DateTime result;
				DateTime.TryParse( SyncTime, out result );
				return result;
			}
			set
			{
				SyncTime = value.ToString();
			}
		}
	}
	[System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true )]
	[System.Xml.Serialization.XmlRootAttribute( Namespace = "", IsNullable = false )]
	public class SyncTimes
	{
		private LastSyncTime[] items;
		[System.Xml.Serialization.XmlElementAttribute( "LastSyncTime", Form = System.Xml.Schema.XmlSchemaForm.Unqualified )]
		public LastSyncTime[] Items
		{
			get
			{
				return items;
			}
			set
			{
				items = value;
			}
		}
		public static SyncTimes OpenXml( string path )
		{
			SyncTimes syncTimes;
			using ( FileStream stream = File.OpenRead( path ) )
			{
				XmlSerializer x = new XmlSerializer( typeof( SyncTimes ) );
				syncTimes = (SyncTimes)x.Deserialize( stream );
			}
			return syncTimes;
		}
		public void ToXmlFile( string path )
		{
			using ( FileStream stream = File.Create( path ) )
			{
				XmlSerializer x = new XmlSerializer( typeof( SyncTimes ) );
				x.Serialize( stream, this );
			}
		}
	}
