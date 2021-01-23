	@using MvcContrib.UI.Grid
	@using MvcContrib.UI.Pager
	@model UsersGridViewModel
	
	@Html.Grid(Model.Results).Columns(cols => {
                                  cols.For(col => col.Id).Sortable(true);
                                  cols.For(col => col.Name).Sortable(true);
                                   //...etc
                                 }).Sort(Model.SortOptions)
								
	
