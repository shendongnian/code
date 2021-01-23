    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ActionWithFileUpload(ViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (Request.Files.Count > 0)
            {
                var postedFile = Request.Files[0];
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    string imagesPath = HttpContext.Server.MapPath("~/Content/Images"); // Or file save folder, etc.
                    string extension = Path.GetExtension(postedFile.FileName);
                    string newFileName = $"NewFile{extension}";
                    string saveToPath = Path.Combine(imagesPath, newFileName);
                    postedFile.SaveAs(saveToPath);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "File not selected.");
            }
        }
        return RedirectToAction("Index"); // Or return view, etc.
    }
