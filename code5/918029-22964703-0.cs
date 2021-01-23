    public List<InventoryPart> GetParts(string partialPartNumber){
        return GetParts(partialPartNumber, null);
    }
    
    public List<InventoryPart> GetParts(string partialPartNumber, string division){
        return GetParts(partialPartNumber, division, null);
    }
    
    public List<InventoryPart> GetParts(string partialPartNumber, string division, int? subDivision){
        return GetParts(partialPartNumber, division, subDivision, null);
    }
    
    public List<InventoryPart> GetParts(string partialPartNumber, string division, int? subDivision, bool? isActive){
        // This method is the one that actually calls the client proxy channels and all.
    }
