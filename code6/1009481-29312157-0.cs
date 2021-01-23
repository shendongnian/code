	public class Panelx : Panel {
		private int _width;
		private int _height;
		private double _proportion;
		private bool _changingSize;
		[DefaultValue(false)]
		public bool MaintainRatio { get; set; }
		public Panelx() {
			MaintainRatio = false;
			_width = this.Width;
			_height = this.Height;
			_proportion = (double)_height / (double)_width;
			_changingSize = false;
		}
		protected override void OnResize(EventArgs eventargs) {
			if (MaintainRatio == true) {
				if (_changingSize == false) {
					_changingSize = true;
					try {
						if (this.Width != _width) {
							this.Height = (int)(this.Width * _proportion);
							_width = this.Width;
						};
						if (this.Height != _height) {
							this.Width = (int)(this.Height / _proportion);
							_height = this.Height;
						};
					}
					finally {
						_changingSize = false;
					}
				}
			}
			base.OnResize(eventargs);
		}
	}
