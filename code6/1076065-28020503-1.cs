     var pics = db.AlbumPictures.Where(p => p.AlbumID == album.ID)
                      .OrderBy(p => p.RankOrder)
                      .Select(p =>
                      {
                          return p.AppendProperty("Thumbnail", ThumbManager.GetThumb(p.ID));
                      })
                      .ToList();
