    //...snip
	public ActionResult List(int? page, GridSortOptions sortOptions, string keyword) {
            var model = new UserGridViewModel();
            IQueryable<User> users = new UserRepository(Session).List();
            if (sortOptions.Column != null) {
                users = users.OrderBy(sortOptions.Column, sortOptions.Direction);
            }
            if (keyword != null) {
                users = users.Where(x => x.Name.Contains(keyword))
            }
            model.SortOptions = sortOptions;
			
			//using MvcContrib.Pagination.PaginationHelper here
            model.Results = users.AsPagination(page ?? 1, 20);
            return View(model);
    }
	//.....
	
