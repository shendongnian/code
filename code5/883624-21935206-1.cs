    [HttpPost]
    public ActionResult RemoveItemEntry(ItemViewModel data)
    {
        // Perform logic to remove the item from the registration 
        // then return the PartialView with updated model
    
        if (Request.IsAjaxRequest())
        {
              return PartialView("~/Views/Partials/ItemEntries.cshtml", model);
        }
        else
        {
              // return the initial View not the parial fie
        }
    }
