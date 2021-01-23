    [HttpPost]
    public JsonResult CalculateAndSaveToDB(BMICalculation CalculateModel)
     {
          if (ModelState.IsValid)
          {
              CalculateModel.Id = User.Identity.GetUserId();
              CalculateModel.Date = System.DateTime.Now;
              CalculateModel.BMICalc = CalculateModel.CalculateMyBMI(CalculateModel.Weight, CalculateModel.Height);
              CalculateModel.BMIMeaning = CalculateModel.BMIInfo(CalculateModel.BMICalc);
              db.BMICalculations.Add(CalculateModel);
              db.SaveChanges();
        }
        return CalculateAndSaveToDB(CalculateModel.BMICalc.ToString(), CalculateModel.BMIMeaning.ToString());
    
