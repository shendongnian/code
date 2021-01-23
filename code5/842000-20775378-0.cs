    public ActionResult _ListBooks()
    {
        var model = new ListBooksViewModel()
        {
            Images = Directory.EnumerateFiles(Server.MapPath("~/BookImageStorage"))
                       .Select(fn => "~/BookImageStorage" + "/"+Path.GetFileName(fn))
        };
        return PartialView(model);
    }
