    public class ProfileController : AuthorizedAccessController
    {
        // GET
        public ActionResult Details(int userId)
        {
            User user = this.Entities.User.First(u => u.Id == userId);
    
            this.Session["ProfilePageAntiforgery"] = Guid.NewGuid(); // use RandomNumberGenerator to generate strong token 
            this.ViewBag.ProfilePageAntiforgery = this.Session["ProfilePageAntiforgery"];
    
            return View(user);
        }
    
        public ActionResult DeleteMyProfile(int userId, string profilePageAntiforgery)
        {
            if ((string)this.Session["ProfilePageAntiforgery"] != profilePageAntiforgery)
            {
                return this.RedirectToAction("Details", new { userId });
            }
    
            User user = this.Entities.User.First(u => u.Id == userId);
            this.Entities.User.Remove(user);
    
            this.Entities.SaveChanges();
    
            return this.RedirectToAction("ProfileDeleted");
        }
    }
