    var calcPoint = new CalcPoint();
    var block = new Block
    {
        CalcPoints = new List<CalcPoint> {calcPoint},
        PerfModes = new List<PerfMode> 
        {
            new PerfMode {CalcPoints = new List<CalcPoint> {calcPoint}}
        }
    };
    using (var context = new TestDbContext())
    {
        context.UpdateGraph(block, map => map
            .OwnedCollection(b => b.CalcPoints)
            .OwnedCollection(b => b.PerfModes, 
                with => with.AssociatedCollection(pm => pm.CalcPoints)));
        
        context.SaveChanges();
    }
    using (var context = new TestDbContext())
    {
        var reloaded = context.Blocks.Include("PerfModes.CalcPoints").Single();
        Assert.AreEqual(1, reloaded.CalcPoints.Count);
        Assert.AreEqual(1, reloaded.PerfModes.Count);
        Assert.AreEqual(1, reloaded.PerfModes[0].CalcPoints.Count);
        Assert.AreEqual(reloaded.CalcPoints[0], reloaded.PerfModes[0].CalcPoints[0]);
    }
