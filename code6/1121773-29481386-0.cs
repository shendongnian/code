    private void RefreshBOM(int designMasterId)
    {
        BOM.Clear();
        var bomResult = BOMCollection.Where(x => x.DesignMasterId == designMasterId);
        if(bomResult != null)
        {
            foreach(var result in bomResult)
            {
                BOM.Add(result);
            }
        }
    }
                
