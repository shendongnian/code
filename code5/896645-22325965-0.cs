    var result = (from c in db.Creatures
                  orderby c.Name
                  select new CardDisplay()
                      {
                          ImgPath = c.Image,
                          CardType = c.CardType.Name,
                          Name = c.Name
                      }).Union(
                    from f in db.Fortunes 
                    orderby f.Name
                    select new CardDisplay()
                        {
                           ImgPath = f.Image,
                           CardType = f.CardType.Name,
                           Name = f.Name
                        }).ToList()
