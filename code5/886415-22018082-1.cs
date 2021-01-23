    List<string> lstfilename = System.IO.Directory
        .EnumerateFiles(dir, "*.txt", System.IO.SearchOption.TopDirectoryOnly)
        .Select(Path => new { 
            Path, 
            split = System.IO.Path.GetFileNameWithoutExtension(Path).Split('-')
        })
        .Where(x => x.split.Length == 2 && x.split.All(s => s.All(Char.IsDigit)))
        .Select(x => new { 
            x.Path, 
            Num1 = int.Parse(x.split[0]),
            Num2 = int.Parse(x.split[1]),
        })
        .Where(x => (startpagenext >= x.Num1 && startpagenext <= x.Num2) 
                 || (endpagenext   >= x.Num1 && endpagenext   <= x.Num2))
        .OrderBy(x => x.Num1).ThenBy(x => x.Num2)
        .Select(x => x.Path)
        .ToList();
