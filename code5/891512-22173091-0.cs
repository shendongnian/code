    routes.MapRoute(
         "TPFurtherRelevantInformation", // Route name
         "TP/FurtherRelevantInformation/{SubstanceId}/{JobServiceMapId}", // URL with parameters
         new { controller = "TP", action = "FurtherRelevantInformation", SubstanceId = UrlParameter.Optional, JobServiceMapId = UrlParameter.Optional }  // Parameter defaults
    );
    
    routes.MapRoute(
          "FurtherRelevantInformation",  // Route name
          "TP/FurtherRelevantInformation/{SubstanceId}", // URL with parameters
          new { controller = "TP", action = "FurtherRelevantInformation", SubstanceId = UrlParameter.Optional }  // Parameter defaults
    );
    routes.MapRoute(
        "TPFurtherRelevantInformationHttpPost",  // Route name
        "TP/FurtherRelevantInformation/{SubstanceId}/{JobServiceMapId}",  // URL with parameters
        new { controller = "TP", action = "FurtherRelevantInformation", SubstanceId = UrlParameter.Optional, JobServiceMapId = UrlParameter.Optional },  // Parameter defaults
        new { httpMethod = new HttpMethodConstraint("POST") }
    );
    routes.MapRoute(
        "FurtherRelevantInformationHttpPost", // Route name
        "TP/FurtherRelevantInformation/{SubstanceId}", // URL with parameters
        new { controller = "TP", action = "FurtherRelevantInformation", SubstanceId = UrlParameter.Optional },  // Parameter defaults
        new { httpMethod = new HttpMethodConstraint("POST") }
    );
