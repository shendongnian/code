    var PumaGoodProduct = db.tbl_dppITHr
            .Where(item => item.ProductionHour >= StartShift && item.ProductionHour <= EndDate)
            .Aggregate(new { MachineTotalSum = 0, MachineClocksSum = 0 },
            (sums, item) => new
            {
                MachineTotalSum  = sums.MachineTotalSum  + item.MachineTotal,
                MachineClocksSum = sums.MachineClocksSum + item.MachineClocks
            });
    Console.WriteLine("MachineTotalSum  : {0}", PumaGoodProduct.MachineTotalSum);
    Console.WriteLine("MachineClocksSum : {0}", PumaGoodProduct.MachineClocksSum);
