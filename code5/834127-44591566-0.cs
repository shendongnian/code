      internal static IHubConnectionContext<IClientNotificationsHub> Hub
        {
            get; set;
        }
 
    if (Hub == null)
     {
         lock (lcoker)
         {
             Hub = this.Clients;
         }
     }
