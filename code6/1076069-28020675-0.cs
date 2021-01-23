    Public Class Album{
       string PhotoUrl {get; set;}
       string ThumbnailUrl {get; set;}
    }
  
    List<AlbumPicture> pics = db.AlbumPictures.Where(p => p.AlbumID == album.ID).OrderBy(p => p.RankOrder).ToList();
    List<Album> albums = new List<Album>();
    foreach(AlbumPicture p in pics)
    {
        albums.add(new Album(){
          PhotoUrl = p.PhotoUrl,//your photo url
          ThumbnailUrl = p.ThumbnailUrl
        });
    }
     return Json(albums, JsonRequestBehavior.AllowGet);
