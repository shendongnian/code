    @model IEnumerable<Project1.Models.Picture>
    @{
    ViewBag.Title = "Animal Pictures";
    }
    
    @Html.RenderAction("PictureUpload");
 
    public ActionResult PictureUpload()
    {
        var model = GetMyPictureUploadViewModel();
        return PartialView("_PictureUpload", model);
    }
