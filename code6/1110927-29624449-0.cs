     Using myDwg.LockDocument
            Using tr = myDwg.TransactionManager.StartTransaction
                'Open the database for Write
                myBT = myDwg.Database.BlockTableId.GetObject(OpenMode.ForRead)
                myBTR = myBT(BlockTableRecord.ModelSpace).GetObject(OpenMode.ForWrite)
                Dim myBlockRef As BlockReference = tr.GetObject(MyIdsCol(0), OpenMode.ForWrite)
                myBlockRef.ScaleFactors = New Scale3d(CType(Xscale, Double), CType(Yscale, Double), CType(Zscale, Double))
                myBlockRef.ExplodeToOwnerSpace()
                myBlockRef.Erase(True)
                Dim btr As BlockTableRecord = tr.GetObject(myBT(Bloknaam), OpenMode.ForWrite, True, True)
                Dim idcoll As ObjectIdCollection = New ObjectIdCollection()
                idcoll.Add(btr.ObjectId)
                myDwg.Database.Purge(idcoll)
                btr.Erase(True)
                tr.Commit()
            End Using
        End Using
