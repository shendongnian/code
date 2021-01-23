    @using (Html.BeginForm("UploadFile", "Home", FormMethod.Post, new { enctype="multipart/form-data" }))
    {
        @Html.TextBoxFor(m => m.FirstName)
        <br /><br />
    
        <input type="file" name="fileUpload" /><br /><br />
        <input type="submit" value="submit me" name="submitme" id="submitme" />
    }
    [HttpPost]
    public ActionResult UploadFile(UploadFileModel model, HttpPostedFileBase fileUpload)
    {
       // DO Stuff
       return View(model);
    }
