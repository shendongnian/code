    public IList<ObjectId> GetIdsByType(Type type)
    {
        Func<Type,RXClass> getClass = RXObject.GetClass;
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
            return polylineIds;
        }
    }
