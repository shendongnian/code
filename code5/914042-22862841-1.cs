    using (var trans = db.TransactionManager.StartTransaction())
    {
        var options = new PromptEntityOptions("\nSelect a 3DPolyline:");
        options.SetRejectMessage("That is not select a 3DPolyline" + "\n");
        options.AddAllowedClass(typeof(Polyline3d), true);
        var result = ed.GetEntity(options);
        if (result.Status != PromptStatus.OK)
            return;
        var poly = (Polyline3d)trans.GetObject(result.ObjectId, OpenMode.ForRead);
        var vertexClass = RXClass.GetClass(typeof(PolylineVertex3d));
        var vertexTable = new System.Data.DataTable("Vertices");
        vertexTable.Columns.Add("HandleId", typeof(long));
        vertexTable.Columns.Add("PositionX", typeof(double));
        vertexTable.Columns.Add("PositionY", typeof(double));
        vertexTable.Columns.Add("PositionZ", typeof(double));
        foreach (ObjectId vertexId in poly)
        {
            if (!vertexId.ObjectClass.IsDerivedFrom(vertexClass))
                continue;
            var vertex = (PolylineVertex3d)trans.GetObject(vertexId, OpenMode.ForRead);
            vertexTable.Rows.Add(vertex.Handle.Value, vertex.Position.X, vertex.Position.Y, vertex.Position.Z);
        }
        trans.Commit();
    }
