    var x = db1.MyStrings.Where(xx => homeStrings.Contains(xx.Content)).ToEnumerable();
    
    var y = db2.MyStaticStringTranslations.ToEnumerable();
    var myStrings = (from a in x
                     join b in y on x.Id equals y.id
                        select new MyStringModel()
                        {
                            Id = x.Id,
                            Original = x.Content,
                            Translation = y.translation
                        }).ToList();
