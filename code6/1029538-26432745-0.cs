    foreach (LoadRelationship relationship in View.SelectedObjects)
    {
    ///This works fine, I get 3 pickup numbers for my selected records///
        List<string> pickUpNumbers = View.SelectedObjects.Cast<LoadRelationship>()
        .Where(x => x != null && x.PurchaseLoad.PickupNumber != null)
        .Select(x => x.PurchaseLoad.PickupNumber)
        .ToList();
    //When assigning the pickUpNumbers.To String to the body of the email it fails here:
    
    string body = "";
    for(int i = 0; i < pickUpNumbers.Count; i++) {
       if (i > 0) {
           body += ", ";
       }
       body += puckUpNumbers[i];
    }
    e.Report.ExportOptions.Email.Body =  body;
    
    
    }
