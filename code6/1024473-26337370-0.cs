    using Microsoft.AspNet.SignalR;
    using System.Threading;
    using System.Diagnostics;
    
    namespace WebApp.SignalR.GridUpdatePanel
    {
        public class DataHub : Hub
        {
            
            public DataHub()
            {
                Debug.Print("Ctor executed...");
                Timer tmr = new Timer(new TimerCallback(this.RefreshThread), null, 1000, 5000);
            }
    
            //Method which invokes the client js code...
            public void Refresh()
            {
                Clients.All.refreshData();            
            }
    
            public void RefreshThread(object obj)
            {
                Debug.Print("RefreshThread Called...");
                Refresh();
            }
        }
    }
