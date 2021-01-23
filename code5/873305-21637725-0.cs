    public class Widget : ViewModelBase
	{
		private double _X;
		public double X
		{
			get { return _X;}
			set { _X = value; RaisePropertyChanged(() => this.X); }
		}
		private double _Y;
		public double Y
		{
			get { return _Y;}
			set { _Y = value; RaisePropertyChanged(() => this.Y); }
		}
		private double _Width;
		public double Width
		{
			get { return _Width;}
			set { _Width = value; RaisePropertyChanged(() => this.Width); }
		}
		private double _Height;
		public double Height
		{
			get { return _Height;}
			set { _Height = value; RaisePropertyChanged(() => this.Height); }
		}
		private System.Windows.Media.Color _Color;
		public System.Windows.Media.Color Color
		{
			get { return _Color;}
			set { _Color = value; RaisePropertyChanged(() => this.Color); }
		}
	}
