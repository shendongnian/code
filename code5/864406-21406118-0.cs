    select new NewBpnRegistrationRequestTypeSubmittedDocument()
                {
    
                     DocumentType = r.Description,
    
                     DocumentUrl = HttpUtility.UrlEncode(spSiteUrl + "/Documents/" + spDocRoot + "/" +
                       thisTaxEntity.TaxEntityPlatformId + "/" + "Registration/" +              
                       s.SharepointDocumentName)
    
                 }).ToArray();
