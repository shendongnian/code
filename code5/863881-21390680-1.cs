     public ActionResult ActionMethodName(FormCollection collection)
        {
            string input = collection.Get("txtAmount");
            int numberOfItems = Convert.ToInt32(string.Join(null, System.Text.RegularExpressions.Regex.Split(input, "[^\\d]")));
    
    
            //float kwota_rachunku=db.RachunekModel.Select(;
    
            ViewBag.Average = db.RachunekModel.OrderByDescending(m => m.RachunekID)  // -< typo fixed here!!
                    .Take(numberOfItems)
                    .Average(m => m.Podatek);
            return View();
    
        }
