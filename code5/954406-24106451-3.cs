    /// <summary>
    /// Represents the ProcessOutputReaderWorkerThreadArguments class.
    /// </summary>
    public class ProcessOutputReaderWorkerThreadArguments
    {
        /// <summary>
        /// Represents the read buffer size,
        /// </summary>
        private int readBufferSize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessOutputReaderWorkerThreadArguments"/> class.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="intermediateDataStore">The intermediate data store.</param>
        public ProcessOutputReaderWorkerThreadArguments(Process process, StringBuilder intermediateDataStore)
        {
            this.ReadBufferSize = 128;
            this.Exit = false;
            this.Process = process;
            this.IntermediateDataStore = intermediateDataStore;
        }
        /// <summary>
        /// Gets or sets a value indicating whether the thread shall exit or not.
        /// </summary>
        public bool Exit
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the read buffer size in bytes.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Is thrown if the specified value is not greather than 0.</exception>
        public int ReadBufferSize
        {
            get
            {
                return this.readBufferSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The specified value for \"ReadBufferSize\" must be greater than 0.");
                }
                this.readBufferSize = value;
            }
        }
        /// <summary>
        /// Gets the process.
        /// </summary>
        public Process Process
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the intermediate data store.
        /// </summary>
        public StringBuilder IntermediateDataStore
        {
            get;
            private set;
        }
    }
