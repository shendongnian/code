    o.Flag =
        o2.Collection1
            .Any(cpd => cpd.Collection1
                .Any(plc => plc.Collection1
                    .Any(vd => vd.DetailedFlag)) ||
                cpd.Collection2
                .Any(plc => plc.Collection1
                    .Any(vd => vd.DetailedFlag)));
