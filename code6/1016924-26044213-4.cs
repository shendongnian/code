    using System;
    using SynchronizingCollection.Common.Model;
    using SynchronizingCollection.Server.Repository;
    using XSockets.Core.XSocket;
    namespace SynchronizingCollection.Server
    {
        public class Demo : XSocketController
        {
            public bool SendUpdates { get; set; }
            public Demo()
            {
                //By default all clients get updates
                SendUpdates = true;
            }
            public void AddOrUpdateModel(MyModel model)
            {
                Repository<Guid, MyModel>.AddOrUpdate(model.Id, model);
            }
            public void RemoveModel(MyModel model)
            {
                Repository<Guid, MyModel>.Remove(model.Id);
            }        
        }
    }
