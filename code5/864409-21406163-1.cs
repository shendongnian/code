    var Docs = (from s in _espEntities.SignupDocuments
                join r in _espEntities.RegistrationRequirements 
                on s.DocumentTypeId equals r.Id
                where s.TaxEntityPlatformId == thisTaxEntity.TaxEntityPlatformId
                select new 
                {
                   DocumentType = r.Description,
                   DocumentUrl = spSiteUrl 
                      + "/Documents/" 
                      + spDocRoot + "/" 
                      + thisTaxEntity.TaxEntityPlatformId 
                      + "/Registration/" 
                      + s.SharepointDocumentName
                })
                .ToArray() // Load data and continue with linq-to-object
                .Select ( n => new NewBpnRegistrationRequestTypeSubmittedDocument
                   {
                     DocumentType  = n.DocumentType,
                     DocumentUrl   = HttpUtility.UrlEncode ( n.DocumentUrl )
                   } )
                .ToArray ();
