    var p = new ProjectFile();
    p.ProjectFileId = dbFile.ProjectFileId;
    p.IsArchived = dbFile.IsArchived;
    p.LastModifyDate = dbFile.LastModifyDate;
    p.Checksum = dbFile.Checksum;
    p.Size = dbFile.Size;
    p.TimeStamp = dbFile.TimeStamp;
    p.UpdateProjectFilesAsArchived(p.UserID, p.ProjectID, p.IsArchived, new int[] { p.projectFileIDs });
