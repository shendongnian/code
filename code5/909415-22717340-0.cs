      RDOSession Session = new RDOSession();
      Session.MAPIOBJECT = Application.Session.MAPIOBJECT;
      RDOMail rItem = (RDOMail)Session.GetRDOObjectFromOutlookObject(item);
      RDOFolder rDestination = (RDOFolder)Session.GetRDOObjectFromOutlookObject(destination);
      rItem.CopyTo(rDestination);
  
