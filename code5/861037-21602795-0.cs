    private void updateFolderPermission(Folder folder, String mail, int per)
    {
      UserId delegateUser = new UserId(mail);
      FolderPermission permission = new FolderPermission(delegateUser, FolderPermissionLevel.None);
      
      switch (per)
      {
        case 0:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.Owner);
            break;
          }
        case 1:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.PublishingEditor);
            break;
          }
        case 2:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.Editor);
            break;
          }
        case 3:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.PublishingAuthor);
            break;
          }
        case 4:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.Author);
            break;
          }
        case 5:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.NoneditingAuthor);
            break;
          }
        case 6:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.Reviewer);
            break;
          }
        case 7:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.Contributor);
            break;
          }
        case 8:
          {
            permission = new FolderPermission(delegateUser, FolderPermissionLevel.None);
            break;
          }
      }
      Folder myFolder = Folder.Bind(this.service, folder.Id);
      FolderPermissionCollection fpc = myFolder.Permissions;
      folder.Permissions.Add(permission);
      foreach (FolderPermission fp in fpc)
      {
        if (fp.UserId.DisplayName != null)
        {
          //folder.Permissions.Add(oldPer);
          if (fp.UserId.PrimarySmtpAddress != mail)
          {
            oldUser = new UserId(fp.UserId.PrimarySmtpAddress);
            oldPer = new FolderPermission(oldUser, fp.PermissionLevel);
            folder.Permissions.Add(oldPer);
          }
        }
      }
      try
      {
        folder.Update();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
