            select new 
                        {
            
                             DocumentType = r.Description,
            
                             DocumentUrl = spSiteUrl + "/Documents/" + spDocRoot + "/" +
                               thisTaxEntity.TaxEntityPlatformId + "/" + "Registration/" +              
                               s.SharepointDocumentName
            
                         }).ToArray().Select(p=>new    
                     NewBpnRegistrationRequestTypeSubmittedDocument{
                      DocumentType =p.DocumentType,
                      DocumentUrl =HttpUtility.UrlEncode(p.DocumentUrl)
                     });
