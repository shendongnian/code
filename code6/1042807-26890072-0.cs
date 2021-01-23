    public void ImportBlocks()
    {
    	DocumentCollection dm =
    	Application.DocumentManager;
    	Editor ed = dm.MdiActiveDocument.Editor;
    	Database destDb = dm.MdiActiveDocument.Database;
    	Database sourceDb = new Database(false, true);
    	try
    	{
    		// Get name of DWG from which to copy blocks
    		var sourceFileName = ed.GetString("\nEnter the path of the source drawing: ");
    		
    		// Read the DWG into a side database
    		sourceDb.ReadDwgFile(sourceFileName.StringResult, System.IO.FileShare.Read, true, "");
    
    		// Create a variable to store the list of block identifiers
    		ObjectIdCollection blockIds = new ObjectIdCollection();
    
    		var tm = sourceDb.TransactionManager;
    		
    		using (var myT = tm.StartOpenCloseTransaction())
    		{
    			// Open the block table
    			BlockTable bt = (BlockTable)myT.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, false);
    
    			// Check each block in the block table
    			foreach (ObjectId btrId in bt)
    			{
    				BlockTableRecord btr =
    				(BlockTableRecord)myT.GetObject(btrId, OpenMode.ForRead, false);
    
    				// Only add named & non-layout blocks to the copy list
    				if (!btr.IsAnonymous && !btr.IsLayout)
    					blockIds.Add(btrId);
    				btr.Dispose();
    			}
    		}
    		// Copy blocks from source to destination database
    		var mapping = new IdMapping();
    		sourceDb.WblockCloneObjects(blockIds,
    			destDb.BlockTableId,
    			mapping,
    			DuplicateRecordCloning.Replace,
    			false);
    	}
    	catch(Autodesk.AutoCAD.Runtime.Exception ex)
    	{
    		ed.WriteMessage("\nError during copy: " + ex.Message);
    	}
    	sourceDb.Dispose();
    }
