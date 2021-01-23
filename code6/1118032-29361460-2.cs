    public ActionResult GetGridData([DataSourceRequest]DataSourceRequest request)
    {
        using (var context = new EntityFrameworkContext()) 
        {
            IQueryable<MyModel> result = context.Products.Where(w => w.Something).Select(s => new MyModel());
            return Json(result.ToDataSourceResult(request));
        }
    }
