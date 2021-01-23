      //Note that I didn't try this code
        public SomeController(ITaxonomyService taxonomyService){
             var product = Services.ContentManager.Get<ContentItem>(33);
             var terms = taxonomyService.GetTermsForContentItem(product.Id); //Or just 33
     
       }
