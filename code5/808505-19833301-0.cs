    class AccelerometerReader: INotifyPropertyChanged, IDisposable {
    	#region Constructor
    	
    	public AccelerometerReader() {
    		new Task(ReadAccelerometer).Start();
    	}
    	
    	#endregion
    	#region INotifyPropertyChanged
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	void FirePropertyChanged(string propertyName) {
    		var propertyChanged = PropertyChanged;
    		if (propertyChanged != null) {
    			propertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    	
    	#endregion
    	#region Properties
    	
    	int _value;
    	public int Value {
    		get { return _value; }
    		set { 
    			if (value != _value) {
    				_value = value;
    				FirePropertyChanged("Value");
    			}
    		}
    	}
    	
    	#endregion
    	#region Accelerometer reading
    	
    	bool _stopLoop = false;
    	
    	void StartReadLoop() {
    		while (!_stopLoop) {
    			Value = ReadAccelerometer();
    			// TODO: Delay a little
    		}
    	}
    	
    	int ReadAccelerometer() {
    		// TODO: Read from accelerometer...
    	}
    	
    	#endregion
    	#region IDisposable
    	
    	public void Dispose() {
    		_stopLoop = true;
    	
    		// TODO: Add a proper IDisposable implementation
    	}
    	
    	#endregion
    }
