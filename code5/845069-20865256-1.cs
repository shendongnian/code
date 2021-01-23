    List<string> lstCategory = new List<string>();
    List<DistributionStandardPackingUnitItems> SPUItemList = new     List<DistributionStandardPackingUnitItems>();
    List<string> prodIDList = new List<string>();
    List<DistributionStandardPackingUnitItems> distSPUItem = new List<DistributionStandardPackingUnitItems>();
    //Get total amount of packages needed by each distribution
    packagesNeeded = prodPackBLL.getPackagesNeededByDistributionID(distributionID);
    
        //Get the items in standard packing unit
    SPUItemList = packBLL.getAllSPUItemByDistributionID(distributionID);
    
    for (int i = 0; i < SPUItemList.Count; i++)
    {
        //Get the product quantity of each item in standard packing unit
        productQuantity = Convert.ToInt32(SPUItemList[i].productQuantity);
    
        //Get the total stock unit of each product in standard packing unit
        totalProductUnit = prodPackBLL.getTotalProductUnit(SPUItemList[i].id);
    
        if ((productQuantity * packagesNeeded) > totalProductUnit)
        {
            //Get the category name of the item which has not enough stock
            category = SPUItemList[i].categoryName;
    
            //Get the list of substitute product with top 5 highest storage level
            List<ProductPacking> prodSubstitute = new List<ProductPacking>();
    
            //Find list of substitute with highest stock level and replace the product
            prodSubstitute = prodPackBLL.getProductIDWithHighestStock(category);
    
            for (int count = 0; count < prodSubstitute.Count; count++)
            {
                //To prevent duplication of same product and check for the listCapacity
                if (prodSubstitute[count].id != SPUItemList[i].id && !prodIDList.Contains(prodSubstitute[count].id) &&  !lstCategory.Contains(category))
                {
                    prodIDList.Add(prodSubstitute[count].id);
                    //listCapacity--;
                    lstCategory.Add(category);
                }
            }
        }
        else
        {
            //If the stock is enough, add it into the prodIDList straight away
            category = SPUItemList[i].categoryName;
            if(!prodIDList.Contains(SPUItemList[i].id) &&   !lstCategory.Contains(category))
            {
                prodIDList.Add(SPUItemList[i].id);
                //listCapacity--;
                lstCategory.Add(category);
            }
        }
    }
