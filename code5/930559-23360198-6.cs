     if (ModelState.IsValid)
     {
         db.CITOYEN.Add(citoyen);
         db.SaveChanges();
         
         ResultModel resultModel = new ResultModel();
         resultModel.TypeOfResult = TypeOfResult.Success;
         //my french is a bit rusty but the result from Google Translate sounds good enough
         resultModel.Message = "Citoyen ajouté avec succès.";
  
         return PartialView("_ResultSummary", resultModel);
     }
