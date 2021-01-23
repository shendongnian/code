    private unsafe void Init(string path, FileMode mode, FileAccess access, int rights, bool useRights, FileShare share, int bufferSize, FileOptions options, Win32Native.SECURITY_ATTRIBUTES secAttrs, string msgPath, bool bFromProxy, bool useLongPath, bool checkHost)
    {
      if (path == null)
        throw new ArgumentNullException("path", Environment.GetResourceString("ArgumentNull_Path"));
      if (path.Length == 0)
        throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
      FileSystemRights fileSystemRights = (FileSystemRights) rights;
      this._fileName = msgPath;
      this._exposedHandle = false;
      FileShare fileShare = share & ~FileShare.Inheritable;
      string paramName = (string) null;
      if (mode < FileMode.CreateNew || mode > FileMode.Append)
        paramName = "mode";
      else if (!useRights && (access < FileAccess.Read || access > FileAccess.ReadWrite))
        paramName = "access";
      else if (useRights && (fileSystemRights < FileSystemRights.ReadData || fileSystemRights > FileSystemRights.FullControl))
        paramName = "rights";
      else if (fileShare < FileShare.None || fileShare > (FileShare.ReadWrite | FileShare.Delete))
        paramName = "share";
      if (paramName != null)
        throw new ArgumentOutOfRangeException(paramName, Environment.GetResourceString("ArgumentOutOfRange_Enum"));
      if (options != FileOptions.None && (options & (FileOptions) 67092479) != FileOptions.None)
        throw new ArgumentOutOfRangeException("options", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
      if (bufferSize <= 0)
        throw new ArgumentOutOfRangeException("bufferSize", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
      if ((!useRights && (access & FileAccess.Write) == (FileAccess) 0 || useRights && (fileSystemRights & FileSystemRights.Write) == (FileSystemRights) 0) && (mode == FileMode.Truncate || mode == FileMode.CreateNew || (mode == FileMode.Create || mode == FileMode.Append)))
      {
        if (!useRights)
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFileMode&AccessCombo", (object) mode, (object) access));
        else
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFileMode&RightsCombo", (object) mode, (object) fileSystemRights));
      }
      else
      {
        if (useRights && mode == FileMode.Truncate)
        {
          if (fileSystemRights == FileSystemRights.Write)
          {
            useRights = false;
            access = FileAccess.Write;
          }
          else
            throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFileModeTruncate&RightsCombo", (object) mode, (object) fileSystemRights));
        }
        int dwDesiredAccess = useRights ? rights : (access == FileAccess.Read ? int.MinValue : (access == FileAccess.Write ? 1073741824 : -1073741824));
        int maxPathLength = useLongPath ? Path.MaxLongPath : Path.MaxPath;
        string path1 = Path.NormalizePath(path, true, maxPathLength);
        this._fileName = path1;
        if (path1.StartsWith("\\\\.\\", StringComparison.Ordinal))
          throw new ArgumentException(Environment.GetResourceString("Arg_DevicesNotSupported"));
        Path.CheckInvalidPathChars(path1, true);
        if (path1.IndexOf(':', 2) != -1)
          throw new NotSupportedException(Environment.GetResourceString("Argument_PathFormatNotSupported"));
        bool flag1 = false;
        if (!useRights && (access & FileAccess.Read) != (FileAccess) 0 || useRights && (fileSystemRights & FileSystemRights.ReadAndExecute) != (FileSystemRights) 0)
        {
          if (mode == FileMode.Append)
            throw new ArgumentException(Environment.GetResourceString("Argument_InvalidAppendMode"));
          flag1 = true;
        }
        if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
        {
          FileIOPermissionAccess access1 = FileIOPermissionAccess.NoAccess;
          if (flag1)
            access1 |= FileIOPermissionAccess.Read;
          if (!useRights && (access & FileAccess.Write) != (FileAccess) 0 || useRights && (fileSystemRights & (FileSystemRights.Write | FileSystemRights.DeleteSubdirectoriesAndFiles | FileSystemRights.Delete | FileSystemRights.ChangePermissions | FileSystemRights.TakeOwnership)) != (FileSystemRights) 0 || useRights && (fileSystemRights & FileSystemRights.Synchronize) != (FileSystemRights) 0 && mode == FileMode.OpenOrCreate)
          {
            if (mode == FileMode.Append)
              access1 |= FileIOPermissionAccess.Append;
            else
              access1 |= FileIOPermissionAccess.Write;
          }
          AccessControlActions control = secAttrs != null && (IntPtr) secAttrs.pSecurityDescriptor != IntPtr.Zero ? AccessControlActions.Change : AccessControlActions.None;
          new FileIOPermission(access1, control, new string[1]
          {
            path1
          }, 0 != 0, 0 != 0).Demand();
        }
        share &= ~FileShare.Inheritable;
        bool flag2 = mode == FileMode.Append;
        if (mode == FileMode.Append)
          mode = FileMode.OpenOrCreate;
        if (FileStream._canUseAsync && (options & FileOptions.Asynchronous) != FileOptions.None)
          this._isAsync = true;
        else
          options &= ~FileOptions.Asynchronous;
        int dwFlagsAndAttributes = (int) (options | (FileOptions) 1048576);
        int newMode = Win32Native.SetErrorMode(1);
        try
        {
          string str = path1;
          if (useLongPath)
            str = Path.AddLongPathPrefix(str);
          this._handle = Win32Native.SafeCreateFile(str, dwDesiredAccess, share, secAttrs, mode, dwFlagsAndAttributes, IntPtr.Zero);
          if (this._handle.IsInvalid)
          {
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode == 3 && path1.Equals(Directory.InternalGetDirectoryRoot(path1)))
              errorCode = 5;
            bool flag3 = false;
            if (!bFromProxy)
            {
              try
              {
                new FileIOPermission(FileIOPermissionAccess.PathDiscovery, new string[1]
                {
                  this._fileName
                }, 0 != 0, 0 != 0).Demand();
                flag3 = true;
              }
              catch (SecurityException ex)
              {
              }
            }
            if (flag3)
              __Error.WinIOError(errorCode, this._fileName);
            else
              __Error.WinIOError(errorCode, msgPath);
          }
        }
        finally
        {
          Win32Native.SetErrorMode(newMode);
        }
        if (Win32Native.GetFileType(this._handle) != 1)
        {
          this._handle.Close();
          throw new NotSupportedException(Environment.GetResourceString("NotSupported_FileStreamOnNonFiles"));
        }
        else
        {
          if (this._isAsync)
          {
            bool flag3 = false;
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Assert();
            try
            {
              flag3 = ThreadPool.BindHandle((SafeHandle) this._handle);
            }
            finally
            {
              CodeAccessPermission.RevertAssert();
              if (!flag3)
                this._handle.Close();
            }
            if (!flag3)
              throw new IOException(Environment.GetResourceString("IO.IO_BindHandleFailed"));
          }
          if (!useRights)
          {
            this._canRead = (access & FileAccess.Read) != (FileAccess) 0;
            this._canWrite = (access & FileAccess.Write) != (FileAccess) 0;
          }
          else
          {
            this._canRead = (fileSystemRights & FileSystemRights.ReadData) != (FileSystemRights) 0;
            this._canWrite = (fileSystemRights & FileSystemRights.WriteData) != (FileSystemRights) 0 || (fileSystemRights & FileSystemRights.AppendData) != (FileSystemRights) 0;
          }
          this._canSeek = true;
          this._isPipe = false;
          this._pos = 0L;
          this._bufferSize = bufferSize;
          this._readPos = 0;
          this._readLen = 0;
          this._writePos = 0;
          if (flag2)
            this._appendStart = this.SeekCore(0L, SeekOrigin.End);
          else
            this._appendStart = -1L;
        }
      }
    }
