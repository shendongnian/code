    public class VehicleViewModel
    {
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
    public ActionResult Vehicles(int? makeId, int? countryId)
    {
        if(!makeId.HasValue || !countryId.HasValue)
        {
            RedirectToAction("Error");
        }
        var models = db.spVehicleGetModels(makeId, false, true, countryId);
        var viewModel = new VehicleViewModel { VehicleModels = models.ToList() };
        return View(viewModel);
    }
