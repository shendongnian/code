    @using RustyLazyLoadTester
    @using RustyLazyLoadTester.Mobile.Models
    @using RustyLazyLoadTester.Mobile.Services.Models
    @{
    ViewBag.PageTitle = "Home";
    ViewBag.Title = string.Format("RustyLazyLoadTester - {0}", ViewBag.PageTitle);
    
    var parameters = new Dictionary<string, object>();
    parameters.Add("status", UserStatus.All);
    }
    @Scripts.Render("~/bundles/lazyload") @* points to /Scripts/rustylazyload.js *@
 
    @Html.Partial("_RustyLazyLoad", new RustyLazyLoadViewModel(
    5, 0, "ulUsers", Url.Action("GetNextUsers", "Home"), parameters))
