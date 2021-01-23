    	  [Serializable()]
	  public class Observer : MapObject
	  {
		private XmlSerializer ser;
		public int ID_Observer { get; set; }
		public double azimuth { get; set; }
		public double Long { get; set; }
		public double Lat { get; set; }
		public double Lenght { get; set; }
		public bool haveConnection { get; set; }
		public bool DrawAzimuth { get; set; }
	  
		/// <summary>
		/// C'tor
		/// </summary>
		public Observer(int ID_Observer = 0, double azimuth = 0, double Lat = 0, double Long = 0, double Lenght = 0, bool haveConnection = true, bool DrawAzimuth = true)
		{
		  this.ID_Observer = ID_Observer;
		  this.azimuth = azimuth;
		  this.Long = Long;
		  this.Lat = Lat;
		  this.haveConnection = haveConnection;
		  this.DrawAzimuth = DrawAzimuth;
		  this.Lenght = Lenght;
		}
		public Observer()
		{
		  ser = new XmlSerializer(this.GetType());
		}
	  }
  
