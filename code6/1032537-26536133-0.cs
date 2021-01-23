    string customPropertyNamespace = "http://schemas.microsoft.com/mapi/string/{00020329-0000-0000-C000-000000000046}/";    
    Outlook.Forlder oFolder = oPublicFolder.Folders["Babillards"].Folders["SYSOTI"].Folders["MEP"];
    
    Redemption.RDOSession session = new RDOSesssion();
    session.MAPUIOBJECT = Application.Session.MAPIOBJECT;
    Redemption.RDOFolder rFolder = session.(RDOFolder)session.GetRDOObjectfromOutlookObject(oFolder);
    Redemption.RDOMail rMsg = rFolder.Items.Add("ipm.note.mep");
    rMsg.Fields[customPropertyNamespace + "prop1"] = "SomeText";
    rMsg.Save();
    //reopen in Outlook and display. Or you can use rMsg.Display()
    Outlook._MailItem oMep = Application.Session.GetItemFromID(rMsg.EntryID);
    oMep.Display(false);
   
    
