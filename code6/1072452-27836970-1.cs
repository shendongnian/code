    public ActionResult List()
      {
        IEnumerable<Product> model =
          _productService.GetProducts();
     
        return View(model);
      }
    @model IEnumerable<MsdnMvcWebGrid.Domain.Product>
    @{
      ViewBag.Title = "Basic Web Grid";
    }
    @{
      var grid = new WebGrid(Model);
    }
    @grid.GetHtml()
