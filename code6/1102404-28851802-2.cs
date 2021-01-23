    public interface IEventProvider
    {
        // This does not have to be a boolean. You can use a string / enum / anything that suits your implementation
        bool Trigger {get; set;}
    }
    
    public class YourPage: Page, IEventProvider
    {
       // Other page methods
    
       protected override void OnLoadComplete(EventArgs e)
       {
         // This will be raised when all the events have fired for all the controls in the page. 
         if(this.Trigger)
            TriggerEvent();
       }
      
       protected void TriggerEvent()
       {
         // Your code here
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
               eventProvider.Trigger = true;
        }
    }
