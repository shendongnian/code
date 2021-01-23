    public object NavigationItems()
    {
        using (TTConnection connection = new TTConnection("ClientDb"))
        {
            if (MySession.Current.MyClub == null)
                return USER_ERROR;
            MiddleTier.WebNavigation.WebNavigationGenerator gen = MySession.Current.NavGenerator;
            List<NavigationElement> list = gen.GetNavigation();
            return list;
        }
    }
