    //your paged partial view partPozicijeView.cshtml
    @model PagedList.IPagedList<WebApplication3.ViewModels.Pozicije>
    @using PagedList.Mvc;
    @{ some code to show table }
    @Html.PagedListPager((IPagedList)ViewBag.ResultsPage,
  
    page => Url.Action("Index", "ControllerName", new { SelectedPosId = YourPosId, page = page},PagedListRenderOptions.PageNumbersOnly)
