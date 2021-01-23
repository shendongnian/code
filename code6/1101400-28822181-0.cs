    protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as SelectVendorViewModel;
    
            if (model == null || !model.VendorId.HasValue || !model.DocumentDate.HasValue || !model.DocumentNumber.HasValue)
            {
                return;
            }
    
            var salesReport = _uow.SalesReportRepository.GetSalesReport(model.VendorId.Value, model.DocumentNumber.Value,
                model.DocumentDate.Value);
            if (salesReport != null)
            {
                model.SalesReportId = salesReport.Id;
            }
           // this is important as we overrode but still need base 
           // functionality to effect a validate
           base.OnModelUpdated(controllerContext, bindingContext);
        }
