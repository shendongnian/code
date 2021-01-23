	public class Monitor
	{
		internal enum eEvent: byte { Layout, Item }
		public Monitor( Test objBeingMonitored )
		{
			objBeingMonitored.BeforeLayoutRendering += ( s, e ) => Before( eEvent.Layout, s, e );
			objBeingMonitored.BeforeItemRendering += ( s, e ) => Before( eEvent.Item, s, e );
			objBeingMonitored.AfterLayoutRendering += ( s, e ) => After( eEvent.Layout, s, e );
			objBeingMonitored.AfterItemRendering += ( s, e ) => After( eEvent.Item, s, e );
		}
		internal void Before( eEvent evt, object sender, EventArgs e ) { }
		internal void After( eEvent evt, object sender, EventArgs e ) { }
	}
