    public ActionResult DeleteMultiple(IEnumerable<QAModel> model)
        {
            _qaService.DeleteMultiple(model);
            long subscriptionId = model.First().SubscriptionId; //value is available here 
            long languageId = model.First().LanguageId;         //value is available here
            return RedirectToAction("Index",new RouteValueDictionary {{"SubscriptionId",subscriptionId},{"LanguageId",languageId},{"Message","Data deleted successfully ."}, } );
    
        }
