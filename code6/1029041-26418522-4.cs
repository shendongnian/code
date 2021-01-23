    ///Example of a Controller method creating a view model to display
	    [HttpGet]
        public ActionResult Index()
        {
	        var user = _userService.Get(User.Identity.Name);
	        var customerId = GlobalDataManager.GetCustomerId();
			if (_error != null)
			{
				ModelState.AddModelError("", _error);
				_error = null;
			}
			var model = new InboundListModel();
			model.Initialize(customerId, user.CompanyId);
			foreach (var campaign in model.Campaigns)
			{
				model.InitializeCallProggress(campaign.Id, _callInfoService.GetCallsCount(campaign.Id));
			}
	        return View(model);
        }
