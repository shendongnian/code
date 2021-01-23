    public partial class MyBusyIndicator : UserControl
    {
        public void ToggleIndicator(bool isBusy)
        {
            // Just an example, in reality you will want to access the BusyIndicator object.
            this.IsBusy = isBusy;
        }
    }
