    var toUpdate = from pc in Settings.ProdCostsAndQtys
                   join s in Settings.SimplifiedPricing
                   on new { prod=pc.improd, list=pc.pplist } equals new { prod=s.PPPROD, list=s.PPLIST }
                   select pc;
    foreach (var prodCost in toUpdate)
    {
        prodCost.pricecur = simplified.PPP01;
        prodCost.priceeur = simplified.PPP01;
    }
