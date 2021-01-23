    public interface IEventProvider
    {
       void TriggerEvent();
       bool Trigger {get;set;}
    }
    public class YourPage: Page, IEventProvider
    {
       protected override void CreateChildControls()
       {
          base.CreateChildControls();
          LoadUserControl();
       }
       
       protected override void OnLoadComplete(EventArgs e)
       {
         // This will be raised when all the events have fired for all the controls in the page. You can handle redirection here as well 
         // with a property to indicate whether redirection is required in the interface IEventProvider.
    
         //if(this.Trigger)
         //{
            //TriggerEvent();
         //}
       }
    
       public void TriggerEvent()
       {
         // Your Implementation
       }
       
       public bool Trigger
       {
         get;
         set;
       }
    }
    
    public class YourUserControl : WebUserControl
    {
        protected void profileBtn_Click(object sender, EventArgs e)
        {
            IEventProvider eventProvider = this.Page as IEventProvider;
            if(eventProvider != null)
            {
               eventProvider.TriggerEvent();
               // Or set a property and handle the OnLoadComplete event in page.
               // eventProvider.Trigger = true;
            }
        }
    }
