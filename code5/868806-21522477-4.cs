    if (!checkLinkEnabled)
    {
        helper.ActionLink( "link text"
                         , actionName
                         , controller
                         , routeValues
                         , htmlAttributes: new Dictionary<string, object>
                           { { "disabled", "disabled" }
                           }
                         );
    }
