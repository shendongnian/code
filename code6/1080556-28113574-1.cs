    public ActionResult Index(string id)
            {
                string busRouteCode = "";
    
                if(string.IsNullOrEmpty(id))
                {
                    if (Request.Cookies["busRouteCode"] == null)
                    {
                        return RedirectToAction("index", "snBusRoutes");
                    }
                    else
                    {
                        busRouteCode = Request.Cookies["busRouteCode"].ToString();                    
                    }    
                }
                else
                {
                    busRouteCode = id;            
    
                }
                 var routeStops = db.routeStops.Include(r => r.busRoute).Where(r => r.busRouteCode == busRouteCode).Include(r => r.busStop);
            return View(routeStops.ToList());
        }
            } 
