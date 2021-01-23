    public ActionResult Search_Names_Using_Location(string b,string d,
                int c=0,int Id=0,)
        {
            ViewBag.Locations = db.Locations.ToList();
            var agentlocation = new AgentLocationViewModel();
    
            agentlocation.agents = new List<Agent>();
    
            var noId = string.IsNullOrWhitespace(Id);
            var noB = string.IsNullOrWhitespace(b);
                agentlocation.agents = (from a in db.Agents
                                        where (noId  || a.LocationId == Id)
                                        && (noB  || a.LocationName == b)
                                        && (a.age > c )
                                        select a).ToList();
    
    
    
            return View(agentlocation);
        }
