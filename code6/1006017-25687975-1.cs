    var enumValues = Enum.GetValues(typeof (EnumType)).Cast<EnumType>().ToArray();
    Enumerable.Range((int) enumValues.Min(), (int) enumValues.Max()).ToDictionary(
    			            x => x.Key,
    			            x => context.Exams.Count(e => e.Classification == x)
    			            );
