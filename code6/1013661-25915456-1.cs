	public class SomeClass
	{
		 private  Manager _m;
		 public Manager M 
		 { 
			get { return _m} 
			set 
			{
                // register/unregister event on property assignment
				if(_m != null)
					_m.RequestChangeSpecialData -= RequestChangeSpecialData;
					
				_m = value;
				
				if(_m != null)
					_m.RequestChangeSpecialData += RequestChangeSpecialData;
			}
		 }
		 public SpecialData data { get; private set; }
		 private void RequestChangeSpecialData(object sender, ChangeSpecialDataEventArgs e)
		 {
            // set the new reference to a SpecialData instance
			data = e.SpecialData;
		 }
		 
	}
	public class Manager
	{
		public void DoSomething()
		{
            // the manager class wants to do something, and wants to change the SpecialData instance.., so it fires the event RequestChangeSpecialData
		    SpecialData data = new SpecialData();
            // if the event is bound.
			if(RequestChangeSpecialData != null)
				RequestChangeSpecialData(this, new ChangeSpecialDataEventArgs(data));
		}
		
		public event EventHandler<ChangeSpecialDataEventArgs> RequestChangeSpecialData;
	}
	public class ChangeSpecialDataEventArgs : EventArgs
	{
		public SpecialData Data {get; private set; }
		
		public ChangeSpecialDataEventArgs(SpecialData Data)
		{
			Data = data;
		}
	}
