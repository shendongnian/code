     var target_dir = "D:\\projectpath\page";
      var isWriteAccess = false;
      try
      {
        var collection = Directory.GetAccessControl(target_dir)
          .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
        if (collection.Cast<FileSystemAccessRule>().Any(rule => rule.AccessControlType == AccessControlType.Allow))
        {
          isWriteAccess = true;
        }
      }
      catch (UnauthorizedAccessException ex)
      {
        isWriteAccess = false;
      }
      catch (Exception ex)
      {
        isWriteAccess = false;
      }
      if (!isWriteAccess)
      {
        MessageBox.Show("no access to directory.");
        // Handle here close and kill the blocking process
        
      }
      else
      {
          Directory.Delete(target_dir, false);
      }
    }
    
