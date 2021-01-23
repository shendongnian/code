     public class CommonBaseViewModel: INotifyPropertyChanged
      {
    		private Dictionary<string, object> Values { get; set; }
    
    		protected CommonBaseViewModel()
    		{
    			this.Values = new Dictionary<string, object>();
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected T GetValue<T>([CallerMemberName] string name=null)
    		{
    			if (this.Values.ContainsKey(name))
    			{
    				return (T)this.Values[name];
    			}
    			else
    			{
    				return default(T);
    			}
    		}
    
    		protected void SetValue(object value, [CallerMemberName] string name =  null)
    		{
    			this.Values[name] = value;
    
    			//notify my property
    			this.OnPropertyChanged(new PropertyChangedEventArgs(name));
    			
    		}
    
    		protected void OnPropertyChanged([CallerMemberName] string name=null)
    		{
    			this.OnPropertyChanged(new PropertyChangedEventArgs(name));
    		}
    
    		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    		{
    			if(this.PropertyChanged != null)
    			{
    				this.PropertyChanged(this, e);
    			}
    		}
    	}
