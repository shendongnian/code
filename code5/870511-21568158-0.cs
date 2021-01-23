    itemList = tempDistSPUI; 
    List<DistributionStandardPackingUnitItems> itemListNew = new List<DistributionStandardPackingUnitItems>();
    itemListNew = packBLL.getAllDistSPUItemByDistributionIDnSPUName(distributionID, SPUname);
    // get all previous IDs in a List<int>
    List<int> previousIDs = itemList.Select(x => x.id).ToList();
    // filter itemListNew and add the elements to itemList
    itemList.AddRange(itemListNew.Where(x => !previousIDs.Contains(x.id));
