       using Umbraco.Core;
       using Umbraco.Core.Models;
       using Umbraco.Core.Services;
           // Get the Umbraco Content Service
        var contentService = Services.ContentService;
        var product = contentService.CreateContent(
            "my new presentation", // the name of the product
            1055, // the parent id should be the id of the group node 
            "Presentation", // the alias of the product Document Type
            0);
        // We need to update properties (product id, original name and the price)
        product.SetValue("title", "My new presentation");
        
        // finally we need to save and publish it (which also saves the product!) - that's done via the Content Service
        contentService.SaveAndPublish(product);
