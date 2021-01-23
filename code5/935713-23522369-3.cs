    public ActionResult WeightCard()
    {
       var weightModel = (from m in db.Weights select m).First();
       var viewModel = new AddWeightModel
       {
            Stone = weightModel.Stone,
            Pound = weightModel.Pount
       };
       return View(viewModel);
    } 
