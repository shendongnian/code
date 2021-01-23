            .Select(s => new 
            {
                // projection
                WebsiteId = s.WebsiteId,
                WebsiteGUID = s.WebsiteGUID,
                WebsiteName = s.WebsiteName,
                WebsiteNotes = s.WebsiteNotes,
                Test = "some test string",
                DefaultContentType = new 
                    { 
                        ContentTypeId = s.DefaultContentTypeID,
                        Description = s.ContentType.Description
                    }
            });
