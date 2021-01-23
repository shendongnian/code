     public ActionResult Index(string EventId)
            {
        
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["User"];
        
                if (cookie != null)
                {
                    string Type = (cookie["Type"] == null || cookie["Type"] == "") ? null : cookie["Type"].ToString();
                    string Username = (cookie["Username"] == null || cookie["Username"] == "") ? null : cookie["Username"].ToString();
                    ViewBag.Message = Type;
                    ViewBag.Username = Username;
        
        
                    try
                    {
                        string ReplaceEventID = EventId.Replace('-', '/');
        
                        ViewBag.Message = ReplaceEventID;
                        IEnumerable<Job> JobListRelatedToEvent = DBContext.Jobs.Where(x => x.EventId == ReplaceEventID);
                        return View(JobListRelatedToEvent);
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
        return View();
            }
