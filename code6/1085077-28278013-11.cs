    @model IEnumerable<FaceToFaceWebsite.Models.PatientHomeViewModel>
    
        @{
            ViewBag.Title = "Home Page";
        }
    
    
        @Html.Partial("_Patient", Model)
