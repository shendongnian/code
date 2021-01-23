    public ActionResult Read([DataSourceRequest] DataSourceRequest request, string searchbox)
        {
            var waybill = db.WayBills.Where(x => x.Status == 1 && x.WaybillNumber.Contains(searchbox));
            var result = waybill.ToDataSourceResult(request, o => new
            {
                WaybillNumber = o.WaybillNumber,
                ETD = o.ETD,
                ETA = o.ETA,
                PIB_Date = o.PIB_Date,
                Description = o.Description,
                CurrencyID = o.CurrencyID,
                PIB_PaymentDate = o.PIB_PaymentDate,
                ShipmentID = o.ShipmentID,
                Status = o.Status
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
