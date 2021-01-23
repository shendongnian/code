    namespace BindingList
    {
    	class Operation : INotifyPropertyChanged
    	{
    		private float _minuend;
    		private float _subtrahend;
    		private float _difference;
    		public float Minuend
    		{
    			get
    			{
    				return this._minuend;
    			}
    
    			set
    			{
    				if (this._minuend == value)
    					return;
    				this._minuend = value;
    				this.NotifyPropertyChanged("Minuend");
    				this.UpdateDifference();
    			}
    		}
    
    		public float Subtrahend
    		{
    			get
    			{
    				return this._subtrahend;
    			}
    
    			set
    			{
    				if (this._subtrahend == value)
    					return;
    				this._subtrahend = value;
    				this.NotifyPropertyChanged("Subtrahend");
    				this.UpdateDifference();
    			}
    		}
    
    		private void UpdateDifference()
    		{
    			this.Difference = this.Minuend - this.Subtrahend;
    		}
    
    		public float Difference
    		{
    			get
    			{
    				return this._difference
    			}
    
    			private set
    			{
    				if (this._difference == value)
    					return;
    				this._difference = value;
    				this.NotifyPropertyChanged("Difference");
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    		private void NotifyPropertyChanged(string p)
    		{
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs(p));
    		}
    	}
    }
