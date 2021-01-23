    public interface IFileSystemService
    {
    
        /// <summary>
        /// Creates all directories and subdirectories as specified by <paramref name="path"/>.    /// 
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.IO.DirectoryInfo"/> as specified by <paramref name="path"/>.    /// 
        /// </returns>
        /// <param name="path">The directory path to create.</param>
        /// <exception cref="T:System.IO.IOException">The directory specified by <paramref name="path"/> is read-only.</exception>
        /// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars"/>.
        /// 
        /// -or-
        /// <paramref name="path"/> is prefixed with, or contains only a colon character (:).</exception>
        ///<exception cref="T:System.ArgumentNullException"><paramref name="path"/> is null.</exception>
        ///<exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        ///<exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        ///<exception cref="T:System.NotSupportedException"><paramref name="path"/> contains a colon character (:) that is not part of a drive label ("C:\").</exception>
        void CreateDirectory(string path);
    
        //Do similar comments for the rest.
        void DeleteDirectory(string path);
        bool DirectoryExists(string path);
        IEnumerable<string> EnumerateDirectories(string path);
        void DeleteFile(string path);
        bool FileExists(string path);
        void CopyFile(string sourcePath, string destinationPath, bool overwriteExisting);
        // ... and other methods   
    }
