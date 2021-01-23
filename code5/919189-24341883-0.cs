    public static Type GetClrTypeFromCSpaceType(
    	this MetadataWorkspace workspace, EdmType cType)
    {
        var itemCollection = (ObjectItemCollection)workspace.GetItemCollection(DataSpace.OSpace);
    
        if (cType is StructuralType) {
            var osType = workspace.GetObjectSpaceType((StructuralType)cType);
            return itemCollection.GetClrType(osType);
        } else if (cType is EnumType) {
            var osType = workspace.GetObjectSpaceType((EnumType)cType);
            return itemCollection.GetClrType(osType);
        } else if (cType is PrimitiveType) {
            return ((PrimitiveType)cType).ClrEquivalentType;
        } else if (cType is CollectionType) {
            return workspace.GetClrTypeFromCSpaceType(((CollectionType)cType).TypeUsage.EdmType);
        } else if (cType is RefType) {
            return workspace.GetClrTypeFromCSpaceType(((RefType)cType).ElementType);
        } else if (cType is EdmFunction) {
            return workspace.GetClrTypeFromCSpaceType(((EdmFunction)cType).ReturnParameter.TypeUsage.EdmType);
        }
    
        return null;
    }
