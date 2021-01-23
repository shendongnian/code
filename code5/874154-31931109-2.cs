      internal static SafeFileHandle GetVolumeHandle( string pathToVolume, NativeMethods.EFileAccess access = NativeMethods.EFileAccess.AccessSystemSecurity | NativeMethods.EFileAccess.GenericRead | NativeMethods.EFileAccess.ReadControl )
      {
        var attributes = ( uint ) NativeMethods.EFileAttributes.BackupSemantics;
        var handle = NativeMethods.CreateFile( pathToVolume, access, 7U, IntPtr.Zero, ( uint ) NativeMethods.ECreationDisposition.OpenExisting, attributes, IntPtr.Zero );
        if ( handle.IsInvalid )
        {
          throw new IOException( "Bad path" );
        }
        return handle;
      }
