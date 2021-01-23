    var objs = ... pt => new
    {
        Id = pt.Id,
        Diam = pt.Diameter,
        Thick = pt.Thickness
    };
    
    var res = objs.AsEnumerable().Select(p => new ViewablePipeTypeModel()
    {
        Id = p.Id,
        KilosPerMeter = Logic.CalculateKilosPerMeter(p.Diam, p.Thick)
    };
