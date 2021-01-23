      public void CreateBlockReference (string strBlockName, Point3d Origin)
      {
       // First: lock document by next instruction
       DocumentLock dl = Application.DocumentManager.MdiActiveDocument.LockDocument ();
       // Second: create separate transaction for each your action
       Transaction   t = db.TransactionManager.StartTransaction ();
    
       try
       {
        // Third: try to make the action your wish
        // here I'm getting the table of Blocks this drawing.dwg
        BlockTable btTable = (BlockTable)t.GetObject (db.BlockTableId, OpenMode.ForRead);
    
        // now get the space of AutoCAD model
        BlockTableRecord btrModelSpace = (BlockTableRecord)t.GetObject (
                                  btTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
    
        if( !btTable.Has (strBlockName) )
        {
         ed.WriteMessage     (string.Format (msgs.BlockNoExist, strBlockName));
         throw new Exception (ErrorStatus.MissingBlockName,
                              string.Format (msgs.BlockNoExist, strBlockName));
        }
        // extract the Block definition, that I want to create a reference
        ObjectId myBlockId = btTable[strBlockName];
    
        // next I'm creating the new instance of my Block by definition
        BlockReference brRefBlock = new BlockReference (Origin, myBlockId);
    
        // insert created blockreference into space of model 
        btrModelSpace.AppendEntity (brRefBlock);
        t.AddNewlyCreatedDBObject (brRefBlock, true);
    
        // successfully close transaction
        t.Commit ();
       } // end try
       finally // or not
       { t.Dispose ();
        dl.Dispose (); // END OF LOCKING!!! ANYWAY
       } // end finally
      }
