                var siteModel = SPMeta2Model
                       .NewSiteModel(site =>
                       {
                           site
                               .WithFields(fields =>
                               {
                                   fields
                                   .AddField(FieldModels.Contact)
                                   .AddField(FieldModels.Details);
                               })
                               .WithContentTypes(contentTypes =>
                               {
                                   contentTypes
                                   .AddContentType(ContentTypeModels.CustomItem)
                                   .AddContentType(ContentTypeModels.CustomDocument);
                               });
                       });
    
                using (var context = new ClientContext(targetSite))
                {
                    var povisionService = new CSOMProvisionService();
                    povisionService.DeployModel(SiteModelHost.FromClientContext(context), siteModel);
                }
