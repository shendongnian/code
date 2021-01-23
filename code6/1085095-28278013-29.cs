        @model FaceToFaceWebsite.Models.PatientListViewModel
        
            @{
                ViewBag.Title = "Home Page";
            }
        
        // PatientListViewModel this is the Name of you class
        // To Access your Model you always have to use Model. Not the Class Name
    // PatientListViewModel is the Class name
    // Model is the Object --> You passed from Controller.
    // Use Model.PatientProfile
    // Not PatientListViewModel.PatientProfile
        @Html.Partial("_Patient", Model.PatientProfile)
