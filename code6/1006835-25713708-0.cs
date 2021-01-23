    var selectedValues = new List<int> { 1, 2, 3 };
	ArticlesModel Obj = new ArticlesModel
	{
	    ArticleId = row.ArticleId,
	    ArticleTitle = row.ArticleTitle,
	    ArticleBody = row.ArticleBody,
	    Featured = row.Featured,
	    Published = row.Published,
	    Widgets = new SelectList(
    	db.Query("SELECT * FROM [Widgets]"), "WidgetId", "WidgetName", selectedValues)
	};
	Obj.SetGlobalProperties(this.ControllerContext.HttpContext.Application);
	ViewData["Article"] = Obj;
