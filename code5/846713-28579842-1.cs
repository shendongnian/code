    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using MicroMvvm;
    
    namespace MyApplication
    {
    	
    	public partial class MyApplication : INotifyPropertyChanged
    	{
    		[field: NonSerialized]
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		private void RaisePropertyChanged(String propertyName)
    		{
    			var handler = PropertyChanged;
    			if (handler == null) return;
    			var e = new PropertyChangedEventArgs(propertyName);
    			handler(this, e);
    		}
    
    		public String IpAdress
    		{
    			get { return _ipAdress; }
    			set
    			{
    				_ipAdress = value;
    				RaisePropertyChanged("IpAdress");
    			}
    		}
    		public MyChild Child
    		{
    			get { return _child; }
    			set
    			{
    				_child = value;
    				RaisePropertyChanged("Child");
    			}
    		}
    		public ICommand AddDotCommand { get { return new RelayCommand(AddDot, null); } }
    		public ICommand ChangeChildCommand { get { return new RelayCommand(ChangeChild, CanChangeChild); } }
    	}
    	
    }
