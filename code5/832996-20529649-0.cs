    var items = (from g in db.Galleries
                      group g by g.GalleryId into k
                         orderby g.SortOrder
                             select new
                             {
                                 Gallery = k.Key,
                                 Medias = (from m in db.Media
                                           where m.GalleryId == k.Key
                                           orderby m.SortOrder
                                           select m).ToList()
                             });
                foreach (var g in items)
                {
                    Console.Writeline(g.Gallery);
                    foreach (var m in g.Medias)
                    {
                        // write your media properties here
                    }
                }
