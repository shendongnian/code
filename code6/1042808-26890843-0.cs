    Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Using lock = doc.LockDocument
                Using OpenDb As New Database(False, False)
                    OpenDb.ReadDwgFile(PathDwg, System.IO.FileShare.ReadWrite, True, "")
                    Dim ids As New ObjectIdCollection()
                    Dim bt As BlockTable
                    Dim sourceBlockId As ObjectId = ObjectId.Null
                    Using tr As Transaction = OpenDb.TransactionManager.StartTransaction()
                        bt = DirectCast(tr.GetObject(OpenDb.BlockTableId, OpenMode.ForRead), BlockTable)
                        If bt.Has(NaamBlok) Then
                            ids.Add(bt(NaamBlok))
                            sourceBlockId = bt(NaamBlok)
                        End If
                        If ids.Count <> 0 Then
                            Dim destdb As Database = doc.Database
                            Dim iMap As New IdMapping()
                            OpenDb.WblockCloneObjects(ids, destdb.BlockTableId, iMap, DuplicateRecordCloning.Replace, False)
                            
                        End If
                        tr.Commit()
                    End Using
                End Using
            End Using
