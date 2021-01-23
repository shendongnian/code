    [CommandMethod("GetClassFromEntityXData", CommandFlags.Modal)]
    //Updated return type here but don't know if it is correct with AutoCAD
    public object GetClassFromEntityXData()
    {
        Database db = Application.DocumentManager.MdiActiveDocument.Database;
        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        object objectToRestore;
        MyUtil util = new MyUtil();
        PromptEntityResult per = ed.GetEntity("Select entity to get class from:\n");
        if (per.Status != PromptStatus.OK)
            return;
        // Get back the class
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            Entity ent = (Entity)tr.GetObject(per.ObjectId, OpenMode.ForRead);
            //Cast to your IClearspan interface here, or use Reflection
            // to determine deserialized object's Type
            objectToRestore = util.NewFromEntity(ent);
            tr.Commit();
        }
        return objectToRestore;
    }
