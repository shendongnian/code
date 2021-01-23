            List<AlbumPicture> pics = db.AlbumPictures.Where(p => p.AlbumID == album.ID).OrderBy(p => p.RankOrder).ToList();
            var lstPics = new List<object>();
            foreach (AlbumPicture p in pics)
            {
                lstPics.Add(new { AlbumPicture = p, Thumbnail = ThumbManager.GetThumb(p.ID) });
            }
            return Json(lstPics, JsonRequestBehavior.AllowGet);
