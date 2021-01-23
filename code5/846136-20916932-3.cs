        bool isAuthorized = false;
        var AuthorizedRoles = SiteMap.CurrentNode.Roles; //obtain the list of authorized roles for the current page
        var UserRoles = Roles.GetRolesForUser(); //obtain the list of roles for the logged-in user
        foreach (string authorizedRoleName in AuthorizedRoles)
        {
            if (isAuthorized == true) //already authorized. no need to check anymore
                break;
            if (authorizedRoleName.Trim() == "*") // this page can be accessed by everyone
            {
                isAuthorized = true;
                break;
            }
            foreach (string userRoleName in UserRoles)
            {
                if (userRoleName.Trim() == authorizedRoleName.Trim())
                {
                    isAuthorized = true;
                    break;
                }
            }
        }
        if (isAuthorized == false)
            Response.End(); // unauthorised user; kill the page.
