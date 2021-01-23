    public ActionResult OpenBidPanelOnItem() {
       var model = GetModelFromSomewhere();
       model.NumberOfVotes++;
       SaveModelToPersistentDataStore(model);
    }
