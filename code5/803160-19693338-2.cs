    /// <summary>
    /// Represents the RemovableDriveWatcherEventArgs
    /// </summary>
    public class RemovableDriveWatcherEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemovableDriveWatcherEventArgs"/> class.
        /// </summary>
        /// <param name="allDrives">All currently available logical drives in the system.</param>
        /// <param name="changedDrive">The changed drive.</param>
        public RemovableDriveWatcherEventArgs(DriveInfo[] allDrives, DriveInfo changedDrive)
        {
            this.Drives = allDrives;
            this.ChangedDrive = changedDrive;
        }
        /// <summary>
        /// Gets the changed logical drive that has either been detected or removed.
        /// </summary>
        public DriveInfo ChangedDrive { get; private set; }
        /// <summary>
        /// Gets all currently available logical drives.
        /// </summary>
        public DriveInfo[] Drives { get; private set; }
    }
