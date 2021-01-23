    public ActionResult Detail(int id)
    {
      var model = db.Renders.Include("Images").Where(r => r.RenderId == id).Select(r => new RenderViewModel()
      {
        RenderId = r.RenderId,
        ClientName = r.ClientName,
        ....,
        Images = r.Images.Select(...), // not sure what your trying to do here
      });
      return View(model);
    }
