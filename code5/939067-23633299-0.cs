        var oem = new Dictionary<string, string>();
            DataTable dt = DataAccessLayer.GetPartsDamaged()
            foreach(DataRow row in dt.Rows)
            {
                oem.Add(row["key"].ToString(),row["value"].ToString());
            }
    
        return RedirectToAction("APNewQuote", new { OENumber = "", QuoteNumber = "", ClaimNumber = ClaimNumber, MotorBodyRepairer = "", VehicleRegistration = vRegistration, vehicleMakeId = "", vehicleModelId = "", vehicleRangeId = "", vehicleMakeModels = "", vehicleModelCode = "", year = vYear, OEParts = oem});
