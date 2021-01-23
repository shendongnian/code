    [ChildActionOnly]
    [AllowAnonymous]
    public ActionResult AnnouncementsLink()
    {
        bool hasNewAnnouncments = false;
        if (User.Identity.IsAuthenticated)
        {
            hasNewAnnouncements = // check for new announcements for user
        }
        return PartialView("_AnnouncmentsLink", hasNewAnnouncements);
    }
