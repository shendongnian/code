    [CommandMethod("DRAWDBCIRCLE")]
    public void DrawDbCircle()
    {
        var acDb = HostApplicationServices.WorkingDatabase;
        var acEd = Application.DocumentManager.MdiActiveDocument.Editor;
        using (var acTrans = acDb.TransactionManager.StartOpenCloseTransaction())
        {
            var bt = (BlockTable)acTrans.GetObject(acDb.BlockTableId, OpenMode.ForWrite);
            var btr = (BlockTableRecord)acTrans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
            Point3d centerPoint;
            double radius;
            string gauge, label, title;
            // Prompt for the centerpoint
            var pointResult = acEd.GetPoint("ENTER CIRCLE ORIGIN: \n");
            centerPoint = pointResult.Value;
            // Prompt for the radius
            var doubleResult = acEd.GetDouble("ENTER CIRCLE RADIUS: \n");
            radius = doubleResult.Value;
            // Prompt for the strings
            var stringResult = acEd.GetString("ENTER CIRCLE GAUGE: \n");
            gauge = stringResult.StringResult;
            stringResult = acEd.GetString("ENTER CIRCLE LABEL: \n");
            label = stringResult.StringResult;
            stringResult = acEd.GetString("ENTER CIRCLE TITLE: \n");
            title = stringResult.StringResult;
            // Create the circle
            var circ = new Circle(centerPoint, Vector3d.ZAxis, radius);
            // <-- Add code for dealing with strings -->
            btr.AppendEntity(circ);
            acTrans.AddNewlyCreatedDBObject(circ, true);
            acTrans.Commit();
        }
    }
