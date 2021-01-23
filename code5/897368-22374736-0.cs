     public static List<CRBT_Promotion> getalbumformis()
            {
                List<CRBT_Promotion> misalbum = new List<CRBT_Promotion>();
                using (crbt_onwebEntities dbcontext = new crbt_onwebEntities())
                {
                   misalbum = (from z in dbcontext.CRBT_Promotion.GroupBy(p=>p.AlbumName).Select(g=>g.FirstOrDefault()) select z).ToList();
                }
                return misalbum;
            }
