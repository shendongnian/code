    var listExamen = context.Examen
        .Select(x => new { x.Prop1, x.Prop2, ... }); // Add properties
    var listExploracion = context.Exploraction
        .Select(x => new { x.Prop1, x.Prop2, ... }); // Add identical properties
    var listCombined = listExamen.Concat(listExploracion);
    var whereAdded = listCombines
        .Where(x => x.Prop1 == someValue);
    var result = whereAdded
        .Skip(skipCount)
        .Take(takeCount)
        .ToList();
