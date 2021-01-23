    public ActionResult Index()
    {
        // Retrieve the viewmodel for the view here, depending on your data structure.
        return View(new EntryViewModel);
    }
    public ActionResult GetData(int categoryId, [DataSourceRequest]DataSourceRequest request)
    {
        var category = _db.Categories.Find(categoryId);
        var model = db.Query<Entry>()
            .OrderBy(en => en.Id)
            .Where(en => en.CategoryId == categoryId)
            .Select(en => new GridViewModel
            {
                Id = en.Id,
                CategoryId = en.CategoryId,
                Title = en.Title,
                Username = en.Username,
                Password = en.Password,
                Url = en.Url,
                Description = en.Description,
            }).AsEnumerable();
    
        return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
    }
    @model IEnumerable<PasswordCloudApp.ViewModels.EntryViewModel>
    @(Html.Kendo().Grid<PasswordCloudApp.ViewModels.GridViewModel>()
        .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(p => p.Title);
            columns.Bound(p => p.Username).Width(100);
            columns.Bound(p => p.Password);
            columns.Bound(p => p.Url);
        })
        .Pageable()
        .Sortable()
        .Scrollable()
        .Filterable()
        .HtmlAttributes(new { style = "height:430px;" })
        .DataSource(dataSource => dataSource
            .Ajax()
            .PageSize(20)
            .Read(read => read.Action("GetData", "Entry", new { categoryId = Model.CategoryID })))
    )
