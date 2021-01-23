    public static IEnumerable<ObjectId> GetIdsByType(this Document doc, params Type[] types)
    {
        Func<Type, RXClass> getClass = RXObject.GetClass;
        var acceptableTypes = new HashSet<RXClass>(types.Select(getClass));
        using (var trans = doc.TransactionManager.StartOpenCloseTransaction())
        {
            var modelspace = (BlockTableRecord)
                trans.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForRead);
            var ids = modelspace.Cast<ObjectId>().Where(id => acceptableTypes.Contains(id.ObjectClass));
            trans.Commit();
            return ids;
        }
    }
