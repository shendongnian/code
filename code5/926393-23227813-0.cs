    string str = "Some string with Some string repeated";
    var result  = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(r => r)
                    .Select(grp => new
                        {
                            Word = grp.Key,
                            Count = grp.Count()
                        });
