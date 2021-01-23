	public class ColorViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		private Color _Color = Colors.Black;
		public double A {
			get { return this.Color.ScA; }
			set {
				this._Color.ScA = ( float )value;
				if ( this.PropertyChanged != null ) {
					this.PropertyChanged( this, new PropertyChangedEventArgs( "A" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
				}
			}
		}
		public double R {
			get { return this.Color.ScR; }
			set {
				this._Color.ScR = ( float )value;
				if ( this.PropertyChanged != null ) {
					this.PropertyChanged( this, new PropertyChangedEventArgs( "R" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Red" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
				}
			}
		}
		public double G {
			get { return this.Color.ScG; }
			set {
				this._Color.ScG = ( float )value;
				if ( this.PropertyChanged != null ) {
					this.PropertyChanged( this, new PropertyChangedEventArgs( "G" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Green" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
				}
			}
		}
		public double B {
			get { return this._Color.ScB; }
			set {
				this._Color.ScB = ( float )value;
				if ( this.PropertyChanged != null ) {
					this.PropertyChanged( this, new PropertyChangedEventArgs( "B" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Blue" ) );
					this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
				}
			}
		}
		public Color Color {
			get { return this._Color; }
			set {
				this._Color = value;
				if ( this.PropertyChanged != null )
					this.AllChanged( );
			}
		}
		public Color Red { get { return Color.FromScRgb( 1.0F, ( float )this.R, 0.0F, 0.0F ); } }
		public Color Green { get { return Color.FromScRgb( 1.0F, 0.0F, ( float )this.G, 0.0F ); } }
		public Color Blue { get { return Color.FromScRgb( 1.0F, 0.0F, 0.0F, ( float )this.B ); } }
		private void AllChanged( ) {
			this.PropertyChanged( this, new PropertyChangedEventArgs( "A" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "R" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "G" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "B" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "Red" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "Green" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "Blue" ) );
			this.PropertyChanged( this, new PropertyChangedEventArgs( "Color" ) );
		}
	}
