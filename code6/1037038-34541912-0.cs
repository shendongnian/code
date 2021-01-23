    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class EventListener
    {
        [DispId(0)]
        public void handler(IHTMLEventObj evt) 
        {
            MessageBox.Show("message received");
        }
    }
    void AddEventListener()
    {
        var evtListener = new EventListener();
        var window = ((IHTMLDocument2)browser.Document).parentWindow as IHTMLWindow3;
        window.attachEvent("MyCustomEvent", evtListener); //or try onMyCustomEvent
    }
