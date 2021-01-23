    class Program {
		static void Dump( ConfigurationElementCollection collection ) {
			foreach ( ConfigurationElement elm in collection ) {
				Console.WriteLine();
				Console.WriteLine(elm.ToString());
				Console.WriteLine();
				foreach ( PropertyInformation prop in elm.ElementInformation.Properties ) {
					Console.Write( prop.Name + ": " );
					if ( prop.Value == null ) {
						Console.WriteLine( "null" );
					} else {
						ConfigurationElementCollection children = prop.Value as ConfigurationElementCollection;
						if ( children != null ) {
							Console.WriteLine( "children<" );
							Console.WriteLine();
							Dump( children );
							Console.WriteLine( ">children" );
							Console.WriteLine( );
						} else {
							Console.WriteLine( prop.Value );
						}
					}
				}
			}
		}
		static void Main( string[] args ) {
			Type tp = typeof( Debug ).Assembly.GetType( "System.Diagnostics.DiagnosticsConfiguration" );
			PropertyInfo propSources = tp.GetProperty( "Sources", BindingFlags.NonPublic | BindingFlags.Static );
			ConfigurationElementCollection sources = (ConfigurationElementCollection)propSources.GetValue( null, null );
			Dump( sources );
			//for ( int i = 0; i < sources.Count; i++ ) {
			//	sources.g
			//}
		}
