    var versions = session
         .CreateCriteria<FileSystemEntryVersion>()
         .Add(Restrictions.Eq("ParentFolder.Id", parentFolderId))
         // we do need a reference here, JOIN in fact, 
         // to include the Many-to-One table          
         .CreateAlias("FileSystemEntry ", "Entry")
         // now the SELECT will contain even the FileSystemEntry table
         // and can start evaluate
         .Add(Restrictions.Eq("Entry.class", typeof(Folder)))))
         .List<FileSystemEntryVersion>();
