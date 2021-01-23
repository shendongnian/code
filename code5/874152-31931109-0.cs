    static void Main( string[ ] args )
    {
      if ( Privileges.HasBackupAndRestorePrivileges )
      {
        using ( var volume = GetVolumeHandle( "C:\\" ) )
        {
          ReadMft( volume );
        }
      }
    }
