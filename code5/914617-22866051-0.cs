    newDataTable = 
        oldDataTable
           .AsEnumerable()
           .GroupBy(r => new { Column1 = row["Column1"], Column2 = row["Column2"] })
           .Select(g => g.First())
           .OrderBy(x => x.Column1)
           .CopyToDataTable(); // your custom extension
