    /// <summary>
    /// Contains extensions used by the RemovableDriveWatcher class.
    /// </summary>
    public static class RemovableDriveWatcherExtensions
    {
        /// <summary>
        /// Extends the DiveInfo[] by the ContainsWithName method.
        /// </summary>
        /// <param name="all">The array where we want to find the specified instance.</param>
        /// <param name="search">The instance which we want to find in the array.</param>
        /// <returns>TRUE if the specified instance was found, FALSE if the specified instance was not found.</returns>
        public static bool ContainsWithName(this DriveInfo[] all, DriveInfo search)
        {
            for (int i = 0; i < all.Length; i++)
            {
                if (all[i].Name == search.Name)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Extends the List<DriveInfo> by the ContainsWithName method.
        /// </summary>
        /// <param name="all">The array where we want to find the specified instance.</param>
        /// <param name="search">The instance which we want to find in the list.</param>
        /// <returns>TRUE if the specified instance was found, FALSE if the specified instance was not found.</returns>
        public static bool ContainsWithName(this List<DriveInfo> all, DriveInfo search)
        {
            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].Name == search.Name)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Extends the List<DriveInfo> by the RemoveWithName method.
        /// </summary>
        /// <param name="all">The array where we want to removed the specified instance.</param>
        /// <param name="search">The instance which we want to remove in the list.</param>
        public static void RemoveWithName(this List<DriveInfo> all, DriveInfo search)
        {
            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].Name == search.Name)
                {
                    all.RemoveAt(i);
                    return;
                }
            }
        }
    }
