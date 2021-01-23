    var imageArray = resourceSet
                         .OfType<DictionaryEntry>()
                         .Select(d => 
                             new
                             {
                                Name = d.Key.ToString(), 
                                Image = (Bitmap)d.Value
                             })
                          .OrderBy(d => d.Name);
                          .ToArray();
