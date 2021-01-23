            var webModel = SPMeta2Model
                   .NewWebModel(web =>
                   {
                       web
                           .WithLists(lists =>
                           {
                               lists
                                   .AddList(ListModels.TestLibrary)
                                   .AddList(ListModels.TestList)
                                   .AddList(ListModels.TestLinksList);
                           });
                   });
            using (var context = new ClientContext(targetSite))
            {
                var povisionService = new CSOMProvisionService();
                povisionService.DeployModel(WebModelHost.FromClientContext(context), webModel);
            }
