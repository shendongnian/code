    /// <summary>
    /// check whether a file can be accessed
    /// --> Warning: No lock is performed, so things may change until you really access the file
    /// </summary>
    /// <param name="fullFilename">name of the file</param>
    /// <returns>true if the fle can be accessed, false in any other case</returns>
    public static bool CanOpenExclusive( string fullFilename )
    {
        Contract.Requires( false == String.IsNullOrWhiteSpace( fullFilename ), "fullFilename is required but is not given" );
        try
        {
            using ( FileStream stream = File.Open( fullFilename, FileMode.Open, FileAccess.Read, FileShare.None ) )
            {
                return true;
            }
        }
        catch( IOException)
        {
            return false;
        }
    }
