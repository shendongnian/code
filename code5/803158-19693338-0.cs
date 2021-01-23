    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    /// <summary>
    /// Represents our program class which contains the entry point of our application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents the entry point of our application.
        /// </summary>
        /// <param name="args">Possibly spcified command line arguments.</param>
        public static void Main(string[] args)
        {
            RemovableDriveWatcher rdw = new RemovableDriveWatcher();   // Create a new instance of the RemoveableDriveWatcher class.
            rdw.NewDriveFound += NewDriveFound;                        // Connect to the "NewDriveFound" event.
            rdw.DriveRemoved += DriveRemoved;                          // Connect to the "DriveRemoved" event.
            rdw.Start();                                               // Start watching.
            // Do something here...
            Console.ReadLine();
            rdw.Stop();                                                // Stop watching.
        }
        /// <summary>
        /// Is executed when a new drive has been found.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The event arguments containing the changed drive.</param>
        private static void NewDriveFound(object sender, RemovableDriveWatcherEventArgs e)
        {
            Console.WriteLine(string.Format("Found a new drive, the name is: {0}", e.ChangedDrive.Name));
        }
        /// <summary>
        /// Is executed when a drive has been removed.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The event arguments containing the changed drive.</param>
        private static void DriveRemoved(object sender, RemovableDriveWatcherEventArgs e)
        {
            Console.WriteLine(string.Format("The drive with the name {0} has been removed.", e.ChangedDrive.Name));
        }
    }
