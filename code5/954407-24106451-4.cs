    /// <summary>
    /// Represents the ProcessOutputReaderEventArgs class.
    /// </summary>
    public class ProcessOutputReaderEventArgs : EventArgs 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessOutputReaderEventArgs"/> class.
        /// </summary>
        /// <param name="intermediateDataStore">The reference to the intermediate data store.</param>
        /// <param name="newData">The new data that has been read.</param>
        public ProcessOutputReaderEventArgs(StringBuilder intermediateDataStore, string newData)
        {
            this.IntermediateDataStore = intermediateDataStore;
            this.NewData = newData;
        }
        /// <summary>
        /// Gets the reference to the intermediate data store.
        /// </summary>
        public StringBuilder IntermediateDataStore
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the new data that has been read.
        /// </summary>
        public string NewData
        {
            get;
            private set;
        }
    }
