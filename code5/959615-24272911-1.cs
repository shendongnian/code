    var acDoc = Application.DocumentManager.MdiActiveDocument;
    var acDb = acDoc.Database;
    using (var tr = database.TransactionManager.StartTransaction())
    {
        try
        {
            var entClass = RXObject.GetClass(typeof(Entity));
            var modelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(acDb);
            var modelSpace = (BlockTableRecord)tr.GetObject(modelSpaceId, OpenMode.ForRead);
            foreach (ObjectId id in modelSpace)
            {
                if (!id.ObjectClass.IsDerivedFrom(entClass)) // For entity this is a little redundant, but it works well with derived classes
                    continue;
                var ent = (Entity)tr.GetObject(id, OpenMode.ForRead)
                
                // Check for the entity's layer
                // You'll need to upgrade the entity to OpenMode.ForWrite if you want to change anything
            }
 
            tr.Commit();
        }
        catch (Autodesk.AutoCAD.Runtime.Exception ex)
        {
            acDoc.Editor.WriteMessage(ex.Message);
        }
    }
 
