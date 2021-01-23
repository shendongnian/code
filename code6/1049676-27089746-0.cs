    public ActionResult Search_Names_Using_Location(string b,string d,
                int c=0,int Id=0,)
        {
            ViewBag.Locations = db.Locations.ToList();
            var agentlocation = new AgentLocationViewModel();
    
            agentlocation.agents = new List<Agent>();
    
    
                agentlocation.agents = (from a in db.Agents
                                        where (string.isNullOrWhitespace(Id) || a.LocationId == Id)
                                        && (string.isNullOrWhitespace(b) || a.LocationName == b)
                                        && (a.age > c )
                                        select a).ToList();
    
    
    
            return View(agentlocation);
        }
