	internal enum MoveFileFlags
	{
	  MOVEFILE_REPLACE_EXISTING = 0x1
	  , MOVEFILE_COPY_ALLOWED = 0x02
	  , MOVEFILE_DELAY_UNTIL_REBOOT = 0x04
	  , MOVEFILE_CREATE_HARDLINK = 0x10
	  , MOVEFILE_WRITE_THROUGH = 0x8
	  , MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x20
	}
	[System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "MoveFileEx")]
	internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);
	public enum DeleteResults { Unauthorized = -2, IOError = -1, NoAction = 0, Deleted = 1, RebootRequired = 2 }
	public static DeleteResults Delete(FileInfo fi)
	{
	  int retries = 40;
	  DeleteResults ret = DeleteResults.NoAction;
	  SpinWait _sw = new SpinWait();
	  while (retries-- > 0 && (ret == DeleteResults.NoAction || ret == DeleteResults.IOError))
	  {
	    fi?.Refresh();
	    if (fi?.Exists ?? false)
	    {
	      fi.IsReadOnly = false;
	      try
	      {
	        fi.Delete();
	        ret = DeleteResults.Deleted;
	      }
	      catch (IOException e)
	      {
	        switch (e.HResult)
	        {
	          case -2147024864:
	            if (MoveFileEx(fi.FullName, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT)) // move to 'null' performs deletion of fi.FullName
	            {
	              ret = DeleteResults.RebootRequired;
	            }
	            else ret = DeleteResults.IOError; //! could make a call to GetLastError,...
	            break;
	          default:
	            ret = DeleteResults.IOError;
	            _sw.SpinOnce();
	            break;
	        }
	      }
	      catch (UnauthorizedAccessException)
	      {
	        ret = DeleteResults.Unauthorized;
	      }
	    }
	    else break;
	  }
	  return ret;
	}
