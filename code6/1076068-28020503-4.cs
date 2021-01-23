    var pics = db.AlbumPictures.Where(p => p.AlbumID == album.ID)
                      .OrderBy(p => p.RankOrder)
                      .Select(p =>
                      {
                          AlbumExt tmp = new AlbumExt();
                          AutoMapper.Mapper.DynamicMap(p, tmp);
                          tmp.Thumbnail = "new prop value";
                          return tmp;
                      })
                      .ToList();
