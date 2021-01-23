    public ActionResult Upload( IEnumerable<HttpPostedFileBase> files ) {
        foreach (var file in files) {
            if (file.ContentLength > 0) {
                // Save your file
            }
        }
    }
