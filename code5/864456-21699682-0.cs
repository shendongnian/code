    /// <summary>
    /// Retrieves the size of the Recycle Bin and the number of items in it, of a specific drive
    /// </summary>
    /// <param name="pszRootPath">The path of the root drive on which the Recycle Bin is located</param>
    /// <param name="pSHQueryRBInfo">A SHQUERYRBINFO structure that receives the Recycle Bin information</param>
    /// <returns></returns>
    [DllImport("shell32.dll")]
    static extern int SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);
       
    /// <summary>
    /// Contains the size and item count information retrieved by the SHQueryRecycleBin function
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SHQUERYRBINFO
    {
        /// <summary>
        /// The size of the structure, in bytes
        /// </summary>
        public int cbSize;
        /// <summary>
        /// The total size of all the objects in the specified Recycle Bin, in bytes
        /// </summary>
        public long i64Size;
        /// <summary>
        /// The total number of items in the specified Recycle Bin
        /// </summary>
        public long i64NumItems;
    }
