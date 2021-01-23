    private readonly IServiceDomain serviceDomain;
    private readonly ICurrentUser currentUser;
    public ServiceController(IServiceDomain serviceDomain, ICurrentUser currentUser)
    {
        this.serviceDomain = serviceDomain;
        this.currentUser = currentUser;
    }
    public ActionResult Home()
    {
        var myServices = this.serviceDomain.GetServicesWithDetails(
            rec => rec.CreatedBy == currentUser.Name);
        var viewModelCollection = myServices.Select(
            service => new DashboardViewModel(service, domain));
        if (this.currentUser.IsInRole("SU"))
            return View("Home_SU", viewModelCollection);
        else if (this.currentUser.IsInRole("Reviewer"))
            return View("Home_Reviewer", viewModelCollection);
        else return View("Home", viewModelCollection);
    }
