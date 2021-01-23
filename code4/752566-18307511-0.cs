    internal static partial class IOUtilities
    {
        /// <summary>
        /// Move a file to an archive folder
        /// </summary>
        /// <remarks>Renames file if necessary to avoid collision.
        /// See <see cref="File.Move"/> for exceptions</remarks>
        /// <param name="file">path to file to move</param>
        /// <param name="targetFolder">folder to move file to</param>
        public static void ArchiveFile(string file, string targetFolder) {
            if (file == null)
                throw new ArgumentNullException("file");
            if (targetFolder == null)
                throw new ArgumentNullException("targetFolder");
            string targetFilename = Path.Combine(targetFolder, Path.GetFileName(file));
            File.Move(file, FindAvailableFilename(targetFilename));
        }
        /// <summary>
        /// Archive file in the same folder
        /// </summary>
        /// <remarks>Renames file by adding first free "(n)" suffix
        /// See <see cref="File.Move"/> for exceptions</remarks>
        /// <param name="file">path to file to archive</param>
        public static void ArchiveFile(string file) {
            if (file == null)
                throw new ArgumentNullException("file");
            File.Move(file, FindAvailableFilename(file));
        }
        /// <summary>
        /// Find a "free" filename by adding (2),(3)...
        /// </summary>
        /// <param name="targetFilename">Complete path to target filename</param>
        /// <returns>First available filename</returns>
        private static string FindAvailableFilename(string targetFilename) {
            if (!File.Exists(targetFilename))
                return targetFilename;
            string filenameFormat = Path.GetFileNameWithoutExtension(targetFilename) + "({0})" + Path.GetExtension(targetFilename);
            string format = Path.Combine(Path.GetDirectoryName(targetFilename), filenameFormat);
            for (int ii = 2;; ++ii) {
                // until we find a filename that doesn't exist
                string newFilename = string.Format(CultureInfo.InvariantCulture, format, ii);
                if (!File.Exists(newFilename)) // returns false on illegal paths, security problems etc
                    return newFilename;
            }
        }
    }
