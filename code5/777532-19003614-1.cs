    public HomepageController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            // Create your new renderModel here, inheriting
            // from RenderModel
            return CurrentTemplate(renderModel);
        }
    }
