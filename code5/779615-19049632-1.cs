    /// <summary>
    /// Opens an existing file for reading.
    /// </summary>
    /// 
    /// <returns>
    /// A read-only <see cref="T:System.IO.FileStream"/> on the specified path.
    /// </returns>
    /// <param name="path">The file to... </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
    public static FileStream OpenRead(string path)
    {
          return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
    }
