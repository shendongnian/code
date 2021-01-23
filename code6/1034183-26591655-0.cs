    var attribute = db.SelectedHarmonyAttributes.SingleOrDefault(x => x.HarmonyAttribute_ID == harmonyAttributeID);
    
    if (attribute != null)
    {
    	attribute.Update(viewModel.ItemCaptionText, viewModel.Isselected, i++); 
    }
    else
    {
    	attribute = new Attribute(viewModel.ItemCaptionText, viewModel.Isselected);
    	db.SelectedHarmonyAttributes.Add(attribute);
    }
    
    db.SaveChanges();
