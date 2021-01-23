    class TaskHandlersFilter : IHandlersFilter
    {
        readonly Dictionary<Type, int> sortOrder = 
            new Dictionary<Type, int>
            {
                {typeof (PrepareSomething), 1},
                {typeof (CarryItOut), 2},
                {typeof (FinishTheJob), 3},
            };
     
        public bool HasOpinionAbout(Type service)
        {
            return service == typeof(ITask);
        }
     
        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            // come up with some way of ordering implementations here
            // (cool solution coming up in the next post... ;))
            return handlers
                .OrderBy(h => sortOrder[h.ComponentModel.Implementation])
                .ToArray();
        }
    }
