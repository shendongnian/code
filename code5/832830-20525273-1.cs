     [HttpPost]
     public ActionResult Upload(ProductImageUploadCreateViewModel viewModel)
     {
          if (!ModelState.IsValid)
          {
               return View(viewModel);
          }
          if (viewModel.ImageFile1 != null)
          {
               UploadImage(viewModel.ProductId, "1", viewModel.ImageFile1);
          }
          // Return to where ever...
     }
