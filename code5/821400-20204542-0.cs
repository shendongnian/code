    var bokningar new Bokningar
    {
        Antalpersoner = 2,
        Bokningsdatum = DateTime.Now,
        DatumFrån = dateTimeBokaFrån.Value,
        DatumTill = dateTimeBokaTill.Value,
        Namn = namnText.Text,
        // Create your Rums here.
        Rums = new List<Rum>{ new Rum { Husdjur = true, ... } }                                      
    });
