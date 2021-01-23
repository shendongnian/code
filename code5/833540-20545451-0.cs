    IEnumerable<string> list =
         numbers.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(s => s.Split(new char[] { ',' }, 
                                         StringSplitOptions.RemoveEmptyEntries))
                .Select(s => int.Parse(s));
