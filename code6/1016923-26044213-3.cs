    using System;
    using SynchronizingCollection.Common.Model;
    using SynchronizingCollection.Server.Repository;
    using XSockets.Core.XSocket;
    using XSockets.Core.XSocket.Helpers;
    using XSockets.Plugin.Framework;
    using XSockets.Plugin.Framework.Attributes;
    namespace SynchronizingCollection.Server
    {
        /// <summary>
        /// Long running controller that will send information to clients about the collection changes
        /// </summary>
        [XSocketMetadata(PluginRange = PluginRange.Internal, PluginAlias = "RepoMonitor")]
        public class RepositoryMonitor : XSocketController
        {
            public RepositoryMonitor()
            {
                Repository<Guid, MyModel>.OnChange += RepositoryOnChanged;
            }
            private void RepositoryOnChanged(object sender, OnChangedArgs<Guid, MyModel> e)
            {
                switch (e.Operation)
                {
                    case Operation.Remove:
                        this.InvokeTo<Demo>(p => p.SendUpdates, e.Value,"removed");
                    break;                    
                    case Operation.AddUpdate:
                        this.InvokeTo<Demo>(p => p.SendUpdates, e.Value, "addorupdated");
                    break;                    
                }
            }       
        }
    }
