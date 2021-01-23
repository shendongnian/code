    public JsonResult ListCardNames(string term)
    {
    	using (BlueBerry_MagicEntities db = new BlueBerry_MagicEntities())
    	{
    		db.Database.Connection.Open();
    
    		var results = from cards in db.V_ITEM_LISTING
    					  where cards.CARD_NAME.ToLower().StartsWith(term.ToLower())
    					  select cards.CARD_NAME + " - " + cards.CARD_SET_NAME;
    
    		JsonResult result = Json(results.ToList(), JsonRequestBehavior.AllowGet);
    
    		return result;
    	}
