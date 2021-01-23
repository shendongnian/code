    public class Cakes
    {
        ...
        public HttpPostedFileBase UploadedFile { get; set; }
    }
    [HttpPost]
    public ActionResult Edit(Cakes cake) // I'd probably use a view model here, not the domain model
    {
          if (ModelState.IsValid)
          {
               if (cakes.UploadedFile != null)
               {
                   cakes.UploadedFile.SaveAs(Path.Combine("path-to-images-for-this-cake", cakes.CakeImage));
               }
               ....
          }
    }
