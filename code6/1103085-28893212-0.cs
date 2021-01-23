    try
    {
        using(new Impersonate(userManager, userName))
        {
           /* do your stuff as userName */
        }
    }
    catch (ImpersonateException) {}
