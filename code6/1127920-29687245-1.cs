	public partial class ColorDefiner : UserControl {
		public static readonly DependencyProperty
			_Color = DependencyProperty.Register( "Color", typeof( Color ), typeof( ColorDefiner ) );
		public Color Color {
			get { return ( Color )this.GetValue( ColorDefiner._Color ); }
			set { this.SetValue( ColorDefiner._Color, value ); }
		}
		private ColorViewModel CVM { get { return this.DataContext as ColorViewModel; } }
		public ColorDefiner( ) {
			InitializeComponent( );
			Binding B = new Binding( "Color" ) { Source = this.DataContext };
			this.SetBinding( ColorDefiner._Color, B );
		}
	}
