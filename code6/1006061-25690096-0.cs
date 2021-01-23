    var stats = context.Persons
        .Select(x => new 
        {
            Level = x.BPDiastolic < 85 && x.BPSystolic < 130
                ? BPLevel.Normal
                : (x.BPDiastolic < 90 && x.BPSystolic < 140
                    ? BPLevel.HighNormal
                    : (x.BPDiastolic < 100 && x.BPSystolic < 160
                        ? BPLevel.HypertensionStage1)
                        : (x.BPDiastolic < 110 && x.BPSystolic < 180
                            ? BPLevel.ModerateHypertensionStage2
                            : BPLevel.SeverHypertensionStage3)))
            
        })
        .GroupBy(x => x.Level)
        .ToDictionary(x => x.Key, g => g.Count()) // execute in database
        .Union(Enum.GetValues(typeof(BPLevel))
            .OfType<BPLevel>()
            .ToDictionary(x => x, x => 0)) // default empty level
        .GroupBy(x => x.Key)
        .ToDictionary(x => x.Key, x => x.Sum(y => y.Value)); // combine both
