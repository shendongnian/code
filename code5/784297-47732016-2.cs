	@using ConservX.Areas.Home.ViewModels.Storying
    @model StoryViewModel
    @{
    	var dataIds = new StoryDataIds
    	{
    		ProjectIds = new[] { 4 }
    	};
    	
    	string title = "Story Title";
    	ViewBag.Title = title;
    	Layout = "~/Areas/Home/Views/Shared/_Main.cshtml";
    }
    @section css {
    ...
