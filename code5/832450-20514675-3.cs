    Dictionary<DateTime, List<ElementMeasurement>> dateMeasurements = mainTable.AsEnumerable()
        .GroupBy(row => row.Field<DateTime>("Date").Date)
        .ToDictionary(g => 
            g.Key,
            g => g.Select(row => new ElementMeasurement
                {
                    Element = new Element { ElementId = row.Field<int>("ElementId") },
                    Field = row.Field<string>("Field"),
                    Value = row.Field<double>("Value"),
                    TimeOfMeasurement = row.Field<DateTime>("Date")
                }).ToList()
    );
