	public class SomeData: INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		private void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "") {
			if (!EqualityComparer<T>.Default.Equals(field, value)) {
				field = value;
				var handler = PropertyChanged;
				if (handler != null) {
				  handler(this, new PropertyChangedEventArgs(name));
				}
			}
		}
		private boolean _someBoolean;
		public int SomeBoolean {
			get { return _someBoolean; }
			set { 
				SetProperty(ref _someBoolean, value);
			}
		}
		private string _someString;
		public string SomeString {
			get { return _someString; }
			set { 
				SetProperty(ref _someString, value);
			}
		}
		
		// etc
	}
	
