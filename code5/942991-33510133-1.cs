    public sealed class RemoteAdminHub : Hub
    {
        #region Properties
        /// <summary>
        /// Gets the SignalR Hub context.
        /// </summary>
        public static IHubContext HubContext
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<RemoteAdminHub>();
            }
        }
        #endregion
    }
