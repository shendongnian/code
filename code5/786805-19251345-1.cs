    internal static class StateManager
    {
        private static XmlSerializer queueSerializer;
        private static readonly string queuePath;
    
        internal static StateManager(){
            try
            {
                queueSerializer = new XmlSerializer(typeof(List<QueueItem>));
                queuePath = Path.Combine(SubSystem.PersistentDirectory, "Queue.xml");
            }
            catch(Exception ex)
            {
                // Log, log, log!
                throw; // Essential: you MUST rethrow!
            }
        }
    }
