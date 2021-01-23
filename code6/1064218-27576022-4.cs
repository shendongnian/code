    public ActionResult Detail(int id)
    {
      var render = db.Renders.Include("Images").Where(r => r.RenderId == id).FirstOrDefault();
      var model = new RenderViewModel()
      {
        RenderId = render.RenderId,
        ClientName = render.ClientName,
        ....,
        Images = render.Images.Select(...), // not sure what your trying to do here
      });
      return View(model);
    }
    
