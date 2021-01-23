    public static class Privileges
    {
      private static int asserted = 0;
      private static bool hasBackupPrivileges = false;
      public static bool HasBackupAndRestorePrivileges
      {
        get { return AssertPriveleges( ); }
      }
      /// <remarks>
      /// First time this method is called, it attempts to set backup privileges for the current process.
      /// Subsequently, it returns the results of that first call.
      /// </remarks>
      private static bool AssertPriveleges( )
      {
        bool success = false;
        var wasAsserted = Interlocked.CompareExchange( ref asserted, 1, 0 );
        if ( wasAsserted == 0 )  // first time here?  come on in!
        {
          success =
            AssertPrivelege( NativeMethods.SE_BACKUP_NAME )
            AssertPrivelege( NativeMethods.SE_RESTORE_NAME );
          hasBackupPrivileges = success;
        }
        return hasBackupPrivileges;
      }
      private static bool AssertPrivelege( string privelege )
      {
        IntPtr token;
        var tokenPrivileges = new NativeMethods.TOKEN_PRIVILEGES( );
        tokenPrivileges.Privileges = new NativeMethods.LUID_AND_ATTRIBUTES[ 1 ];
        var success =
          NativeMethods.OpenProcessToken( NativeMethods.GetCurrentProcess( ), NativeMethods.TOKEN_ADJUST_PRIVILEGES, out token )
          &&
          NativeMethods.LookupPrivilegeValue( null, privelege, out tokenPrivileges.Privileges[ 0 ].Luid );
        try
        {
          if ( success )
          {
            tokenPrivileges.PrivilegeCount = 1;
            tokenPrivileges.Privileges[ 0 ].Attributes = NativeMethods.SE_PRIVILEGE_ENABLED;
            success =
              NativeMethods.AdjustTokenPrivileges( token, false, ref tokenPrivileges, Marshal.SizeOf( tokenPrivileges ), IntPtr.Zero, IntPtr.Zero )
              &&
              ( Marshal.GetLastWin32Error( ) == 0 );
          }
          if ( !success )
          {
            Console.WriteLine( "Could not assert privilege: " + privelege );
          }
        }
        finally
        {
          NativeMethods.CloseHandle( token );
        }
        return success;
      }
    }
