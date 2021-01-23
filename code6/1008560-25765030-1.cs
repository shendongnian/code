        /// <summary>
        /// Dispose all used resources.
        /// </summary>
        public void Dispose()
        {
           ////code
            GC.SuppressFinalize(this);
        }
