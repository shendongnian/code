    var lineInfo = file.AsParallel().AsOrdered()
        .Select((line, index) => new
        {     
             ....
        }
     })
     .ToList()
     .AsParallel();
