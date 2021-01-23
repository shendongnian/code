    var query = Directory.EnumerateFiles("c:\\Catalogues", "*.*", SearchOption.AllDirectories)
       .GroupBy(file => Path.GetExtension(file))
       .Select(grp => new
       {
           Extension = grp.Key,
           FileName = grp.First(),
           Count = grp.Count()
       }).ToList();
