    public static List<CRBT_Promotion> getalbumformis()
            {
                List<CRBT_Promotion> misalbum = new List<CRBT_Promotion>();
                using (crbt_onwebEntities dbcontext = new crbt_onwebEntities())
                {
                     misalbum = from z in dbcontext.CRBT_Promotion   
    				.GroupBy(p => new CRBT_Promotion {p.AlbumName} )
    				.Select(g => g.First())
    				.ToList(); 
                }
                return misalbum;
            }
    
    public ActionResult MISAlbum()
            {
                AlbumSongModel s = new AlbumSongModel();
                s.albums = implement.getalbumformis();
                return View("MISAlbum",s);
            }
          
