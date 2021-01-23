    public class DatabaseDispatcher : IDatabase
    {
        private readonly SQLReposity primaryStore;
        private readonly WFCReposity fallbackStore;
        private readonly VistaDBReposity persistentStore;
        public DatabaseDispatcher(
            SQLReposity primaryStore,
            WFCReposity fallbackStore,
            VistaDBReposity persistentStore) {
            this.primaryStore = primaryStore;
            this.fallbackStore = fallbackStore;
            this.persistentStore = persistentStore;
        }
        // IDatabase methods here. Example:
        public TResult Execute<TResult>(IQuery<TResult> query)
            try {
                return GetCurrentStore().Execute<TResult>(query);
            } catch (Exception ex) {
               // Decide what to do here. Is primary store offline? Then fallback
            }
        }
        private IDatabase GetCurrentStore() {
           // complex fallback logic here.
        }
    }
