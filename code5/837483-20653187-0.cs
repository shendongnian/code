    var filename1 = "10-file.txt";
    var filename2 = "2-file.txt";
    var filenames = new []{filename1, filename2};
    var sorted = 
        filenames.Select(fn => new { 
                                      nr = int.Parse(new string(
                                                 fn.SkipWhile(c => !Char.IsNumber(c))
                                                   .TakeWhile(c => Char.IsNumber(c))
                                                   .ToArray())), 
                                      name = fn
                                    })
                  .OrderBy(file => file.nr)
                  .Select(file => file.name);
