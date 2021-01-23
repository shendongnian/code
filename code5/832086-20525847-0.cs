    [CommandMethod("MathIsCool")]
    public void Draw_Method()
    {
        Database db = HostApplicationServices.WorkingDatabase;
        Editor ed = AcadApplication.DocumentManager.MdiActiveDocument.Editor;
        // Parameters (get from user prompt if desired)
        var startP = new Point3d(0, 0, 0);
        var r = 5.64;
        var lineGap = 0.4;
        var chordLen = r * 0.40;
        try
        {
            using (Transaction acTrans = db.TransactionManager.StartTransaction())
            {
                var bt = (BlockTable)acTrans.GetObject(db.BlockTableId, OpenMode.ForWrite);
                var btr = (BlockTableRecord)acTrans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                // Create the circle
                var circ = new Circle(startP, Vector3d.ZAxis, r);
                btr.AppendEntity(circ);
                acTrans.AddNewlyCreatedDBObject(circ, true);
                // Create the horizontal line
                var hPt1 = new Point3d(startP.X - (chordLen / 2), startP.Y + (r + lineGap), 0);
                var hPt2 = new Point3d(hPt1.X + chordLen, hPt1.Y, 0);
                var hLine = new Line(hPt1, hPt2);
                btr.AppendEntity(hLine);
                acTrans.AddNewlyCreatedDBObject(hLine, true);
                // Create the vertical line
                // Arc sagitta = Sqrt(r*r-l*l);
                var sag = Math.Sqrt(r * r - (chordLen / 2) * (chordLen / 2));
                var vPt2 = new Point3d(hPt1.X, sag, 0);
                var vLine = new Line(hPt1, vPt2);
                btr.AppendEntity(vLine);
                acTrans.AddNewlyCreatedDBObject(vLine, true);
                acTrans.Commit();
            }
        }
        catch (System.Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            ed.WriteMessage(ex.ToString());
        }
    }
