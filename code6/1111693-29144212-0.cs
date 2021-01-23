     public JsonResult GetGuarantorSummary([DataSourceRequest] DataSourceRequest request, string packageId, string packageProductId)
            {
               // GuarantorModel objGuarantorModel = new GuarantorModel();
                try
                {
                    //Guarantors objGuarantors = new Guarantors(packageId, packageProductId);
                    // objGuarantorModel = objGuarantors.GetGuarantorsSummary();
                    //objGuarantorModel = GetGuarantorsStubbedData();
                    List<EntryPointCRR.Models.GuarantorInfo> model = new List<EntryPointCRR.Models.GuarantorInfo>();
                    //get your collection here:
                    //TODO: My collection 
                }
                catch (Exception ex)
                {
                    Logger.Write(ex, "General", 1, 1, System.Diagnostics.TraceEventType.Error);
                }
                return Json(model.ToDataSourceResult(request, ModelState), JsonRequestBehavior.DenyGet);
            }
