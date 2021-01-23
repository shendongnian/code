    public interface IMyInterface
    {   
        event EventHandler OnSomeEvent;
		void addSomeData(string value);
		void getSomeData();
    }
    public class MyInterface: IMyInterface
    {
        public event EventHandler OnSomeEvent = delegate { };  
        
        public void addSomeData(string value)
        {
            // do stuff
			OnSomeEvent();
        }
        public string getSomeData()
        {
            return "some data";
        }
    }
	
	// Main ViewModel
	public class ViewModelOne : ViewModelBase
    {
		IMyInterface myInterface;
        public NotifyViewModel(IMyInterface myInterface)
        {
            this.myInterface = myInterface;
            this.myInterface.OnItemSourceChanged += myInterface_OnSomeEvent;
        }
		
		void testEvent()
        {
            this.myInterface.addSomeData("test data");
        }
	}
	
	// My nested user control
	public class ViewModelTwo : ViewModelBase
    {
		IMyInterface myInterface;
        public NotifyViewModel(IMyInterface myInterface)
        {
            this.myInterface = myInterface;
            this.myInterface.OnItemSourceChanged += myInterface_OnSomeEvent;
        }
		
		void myInterface_OnSomeEvent(object sender, System.EventArgs e)
        {
            // do stuff
        }
	}
	
