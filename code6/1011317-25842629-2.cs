    return context.IMPORTAWBs
             .GroupJoin(context.GODOWNRENTs,
                        i => i.AWBNO, r => r.AWBNO, (item, rents) => new { item, rents })
             .Where(x => !x.rents.Any())
             .Select(x => x.item)
             .ToList();
