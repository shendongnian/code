    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace TestAttachedPropertyValidationError
    {
    	public class ViewModel :INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		private int _vmNumericProp;
    		private bool _vmNumericPropHasError;
    
    		public int VmNumericProp
    		{
    			get { return _vmNumericProp; }
    			set
    			{
    				_vmNumericProp = value;
    				OnPropertyChanged();
    			}
    		}
    
    		public bool VmNumericPropHasError
    		{
    			get { return _vmNumericPropHasError; }
    			set
    			{
    				_vmNumericPropHasError = value;
    				OnPropertyChanged();
    			}
    		}
    
    		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    		{
    			var handler = PropertyChanged;
    			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
