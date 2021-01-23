       var parentTerm = _taxonomyService.NewTerm(categoriesTaxonomy);
       parentTerm.Container = categoriesTaxonomy.ContentItem;
       // Create content item before updating so attached fields save correctly
       _orchardServices.ContentManager.Create(parentTerm, VersionOptions.Draft);
       parentTerm.Name = "main category";
       parentTerm.Selectable = true;
       _taxonomyService.ProcessPath(parentTerm);
       _orchardServices.ContentManager.Publish(parentTerm.ContentItem);
       var subTerm = _taxonomyService.NewTerm(categoriesTaxonomy);
       //here you set the parent term
       subTerm.Container = parentTerm == null ? categoriesTaxonomy.ContentItem : parentTerm.ContentItem;
       // Create content item before updating so attached fields save correctly
       _orchardServices.ContentManager.Create(subTerm, VersionOptions.Draft);
       subTerm.Name = "sub category";
       subTerm.Selectable = true;
       _taxonomyService.ProcessPath(subTerm);
       _orchardServices.ContentManager.Publish(subTerm.ContentItem);
