    public ActionResult WeightCard()
    {
       var weightModel = from m in db.Weights where select m;
       var viewModel = new AddWeightModel
       {
            Stone = weightModel.Stone,
            Pound = weightModel.Pount
       };
       return View(viewModel);
    } 
