    public ActionResult FunHome(int? valueskip, int? valuetake) {
        var query = (from u in db.CardTables
                     select new CardModel {
                         cardDate = u.CardDate,
                         cardFileName = u.CardFileName,
                         cardFilePath = u.CardFilePath,
                         cardHashCode = u.CardHashCode,
                         cardID = u.CardID,
                         cardTitle = u.CardTitle
                     });
        if (valuetake == null && valueskip == null) {
            int take = 5;
    
            var cardlist = query.Take(take);
    
            return View(cardlist);
        }
        else {
            int skip = Convert.ToInt32(valueskip);
            int take = Convert.ToInt32(valuetake);
            var cardlist = query.Skip(skip).Take(take);
            return PartialView("FunHome", cardlist);
        }
    }
