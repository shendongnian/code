        /// <summary>
        /// This will return 0 through 7 continuously in a thread-safe manner.
        /// </summary>
        /// <returns>0, 1, 2, 3, 4, 5, 6, 7, and then back to 0.</returns>
        private const int maxIndex = 7; // warning - must be a ([power-of-two number] - 1)
        private static int currentQueueIndex = -1;
        private static int GetNextQueueIndex()
        {
            return Interlocked.Increment(ref currentQueueIndex) & (maxIndex);
        }
