    @model Web.UI.Models.Errors.ErrorViewModel
    
    @{
        int errorCode = Convert.ToInt32(@ViewBag.error);
    
    
        switch (errorCode)
        {
            case 404:
                ViewBag.Title = "404 Page Not Found";
                Html.RenderPartial("~/Views/Shared/ErrorPages/HttpError404.cshtml");
                break;
            case 500:
                ViewBag.Title = "Error Occurred";
                Html.RenderPartial("~/Views/Shared/_Error.cshtml");
                break;
            default:
                ViewBag.Title = @Model.DisplayErrorPageTitle;
                Html.RenderPartial("~/Views/Shared/ErrorPages/HttpNoResultsFound.cshtml");
                break;
        }
    } 
