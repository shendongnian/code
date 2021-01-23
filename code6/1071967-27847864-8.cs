    [CommandMethod("PlineITR")]
    public void GetIdsByType()
    {
        var sw = new Stopwatch();
        sw.Start();
        Func<Type, RXClass> getClass = RXObject.GetClass;
        // You can set this anywhere
        var acceptableTypes = new HashSet<RXClass>
        {
            getClass(typeof(Polyline)),
            getClass(typeof (Polyline2d)),
            getClass(typeof (Polyline3d))
        };
        var doc = Application.DocumentManager.MdiActiveDocument;
        using (var trans = doc.TransactionManager.StartOpenCloseTransaction())
        {
            var modelspace = (BlockTableRecord)
            trans.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForRead);
            var polylineIds = (from id in modelspace.Cast<ObjectId>()
                               where acceptableTypes.Contains(id.ObjectClass)
                               select id).ToList();
            trans.Commit();
            sw.Stop();
            doc.Editor.WriteMessage(
                string.Format("iteration:\n\t ticks: {0}\n\t time: {2}  \n\tcount = {1}\n\t", sw.ElapsedTicks, polylineIds.Count, sw.ElapsedMilliseconds));
            //return polylineIds;
        }
    }
    [CommandMethod("PlineTV")]
    public void SelectAllPolyline()
    {
        var sw = new Stopwatch();
        sw.Start();
        ObjectIdCollection retVal = null;
        var doc = Application.DocumentManager.MdiActiveDocument;
        Editor oEd = doc.Editor;
        try
        {
            // Get a selection set of all possible polyline entities on the requested layer
            PromptSelectionResult oPSR = null;
            TypedValue[] tvs =  {
        new TypedValue(Convert.ToInt32(DxfCode.Operator), "<or"),
        new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE"),
        new TypedValue(Convert.ToInt32(DxfCode.Start), "LWPOLYLINE"),
        new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE2D"),
        new TypedValue(Convert.ToInt32(DxfCode.Start), "POLYLINE3d"),
        new TypedValue(Convert.ToInt32(DxfCode.Operator), "or>")
    };
            SelectionFilter oSf = new SelectionFilter(tvs);
            oPSR = oEd.SelectAll(oSf);
            if (oPSR.Status == PromptStatus.OK)
            {
                retVal = new ObjectIdCollection(oPSR.Value.GetObjectIds());
            }
        }
        catch (System.Exception ex)
        {
            throw;
        }
        sw.Stop();
        doc.Editor.WriteMessage(string.Format("typedvalue:\n\t ticks: {0}\n\t time: {2}  \n\tcount = {1}\n\t", sw.ElapsedTicks, retVal.Count,sw.ElapsedMilliseconds ));
        //return retVal;
    }
