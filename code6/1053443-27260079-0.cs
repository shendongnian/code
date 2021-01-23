        [CommandMethod("getLines")]
        public void OpenDrawing()
        {
            OpenDrawingGetLines(@"C:\saved\linetest.dwg");
        }
        public void OpenDrawingGetLines(string path)
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            if (!File.Exists(path))
            {
                editor.WriteMessage(string.Format(@"{0} doesn't exist.", path));
                return;
            }
            // wrap in using statement to open and close.
            var doc = Application.DocumentManager.Open(path, false);
            string docName = string.Empty;
            IEnumerable<ObjectId> lineIds;
            // lock the doc
            using (doc.LockDocument())
            // start transaction
            using (var trans = doc.TransactionManager.StartOpenCloseTransaction())
            {
                // get the modelspace
                var modelspace = (BlockTableRecord)
                   trans.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForRead);
                // get the lines ObjectIds
                lineIds = from id in modelspace.Cast<ObjectId>()
                          where id.ObjectClass.IsDerivedFrom(RXObject.GetClass(typeof(Line)))
                          select id;
                docName = doc.Name;
                trans.Commit();
            }
            var message = string.Format("{0} Lines in {1}", lineIds.Count(), docName);
            editor.WriteMessage(message);
            Application.ShowAlertDialog(message);
        }
