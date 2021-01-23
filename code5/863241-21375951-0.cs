    List<ProductPacking> prodSubstitute = new List<ProductPacking>();
        List<DistributionStandardPackingUnitItems> distSPUItem = newList<DistributionStandardPackingUnitItems>();
        
                    var q = prodSubstitute.Where(item => distSPUItem.Select(item2 => item2).Contains(item));
                    var y = prodSubstitute .Except(distSPUItem ); // y will have 2, since 2 are not included in list2
        
                    foreach (var i in q)
                    {
                       //Perform something here
                    }
