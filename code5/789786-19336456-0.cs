    routes.MapPageRoute("Subject details",
                  "subject/{" + Utils.Constants.RouteVariables.SubjectChosen + "}/{" + Utils.Constants.RouteVariables.SubjectAction + "}",
                  "~/SubjectDetails.aspx");
    
    routes.MapPageRoute("Laes Blog",
        "{Year}/{Month}/{BlogHeadline}",
        "~/ReadBlogEntry.aspx");
