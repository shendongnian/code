    public ActionResult Index(string SearchParam)
            {
    
                var search1= (dynamic)null;
    
                var search= from m in db.Table1
                              select m;
    
    
                int selec = 0;
    
                if (User.Identity.IsAuthenticated)
                {
    
                    if (!String.IsNullOrEmpty(SearchParam))
                    {
                        search= search.Where(s => s.CommonName.Contains(SearchParam) || s.SciName.Contains(SearchParam));
                        selec = 1;
                    }
             
                    search1= (from d in db.Table1
                                select d).OrderBy(p => p.CommonName);
    
    
                }
                else
                {
                    if (!String.IsNullOrEmpty(SearchParam))
                    {
                        search= search.Where(s => s.CommonName.Contains(SearchParam)||s.SciName.Contains(SearchParam)).Where(s => s.State.Equals(true));
                        selec = 1;
                    }
    
                    search1= (from d in db.Table1
                                where d.State== true
                                select d).OrderBy(p => p.CommonName);
                }
    
                if (selec == 0)
                {
                    return View(search1);
                }
                return View(search);
    
            }
