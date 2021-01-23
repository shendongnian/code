    public partial class YourOtherSublayout : System.Web.UI.UserControl
    {
        private System.EventHandler eventHandlerRef;
        protected void Page_Load(object sender, EventArgs e)
        {
            eventHandlerRef = EventHandlerMethod;
            Sitecore.Events.Event.Subscribe("YourEventName", eventHandlerRef);
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (eventHandlerRef != null)
            {
                Sitecore.Events.Event.Unsubscribe("YourEventName", eventHandlerRef);
            }
        }
        private void EventHandlerMethod(object sender, EventArgs e)
        {
            if (e != null)
            {
                //do stuff here
            }
        }
    }
