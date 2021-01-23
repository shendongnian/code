        public ActionResult RenderPostMessage(string surfaceType, string otherValue, string newValue)
        {
            var viewModel = new PostMessageViewModel();
    viewModel.SurfaceType = surfaceType;
    viewModel.OtherValue = otherValue;
    viewModel.NewValue = newValue;
            return PartialView("PostMessage", viewModel);
        }
