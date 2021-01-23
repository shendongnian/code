      if (workspace !=null)
      {
           foreach(var folder in workspace.Folders)
           {
                 if (!folder.IsCloaked && folder.LocalItem != "some expected path")
                 {
                      // mapping invalid, throw/log?
                 }
           }
      }
     
