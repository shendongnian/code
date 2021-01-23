    public class StateManager : INotifyPropertyChanged
    {
        private static StateManager instance = new StateManager();
        /// <summary>
        /// Initialises a new empty StateManager object.
        /// </summary>
        public StateManager() { }
        /// <summary>
        /// Gets the single available instance of the application StateManager object.
        /// </summary>
        public StateManager Instance
        {
            get { return instance; }
        }
        ...
    }
