    var pics = db.AlbumPictures.Where(p => p.AlbumID == album.ID)
              .OrderBy(p => p.RankOrder)
              .Select(p=> 
                      { dynamic copy = p.ToDynamic();
                        copy.Thumbnail = ThumbManager.GetThumb(p.ID); //You can add more dynamic properties here
                        return copy;
                      })
              .ToList();
    return Json(pics, JsonRequestBehavior.AllowGet);
