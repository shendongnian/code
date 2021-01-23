    public interface IEventProvider
    {
      void TriggerEvent();  
    }
    
    public class YourPage: Page, IEventProvider
    {
       // Other page methods
    
       public void TriggerEvent()
       {
         // Your Implementation
       }
    }
    
    public class YourUserControl : WebUserControl
    {
        protected void profileBtn_Click(object sender, EventArgs e)
        {
            IEventProvider eventProvider = this.Page as IEventProvider;
            if(eventProvider != null)
               eventProvider.TriggerEvent();
        }
    }
