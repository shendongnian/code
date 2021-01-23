    var Gdupes = itemList.GroupBy(x => x.ID).Where(x => x.Skip(1).Any()).ToList();
    List<DistributionStandardPackingUnitItems> dupes = new List<DistributionStandardPackingUnitItems>();
    foreach (IGrouping<int, DistributionStandardPackingUnitItems> element in Gdupes)
    {
        List<DistributionStandardPackingUnitItems> tenp = itemList.Where(x => x.Age == element.Key).Skip(1).ToList();
        foreach (DistributionStandardPackingUnitItems s in tenp)
        {
            dupes.Add(s);
        }
    }
    prodVariantDetail = itemList.Except(dupes).ToList();
