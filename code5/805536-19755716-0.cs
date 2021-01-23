    void RegisterRoutes(RouteCollection routes)
        {
            int language = 2;
            routes.Clear();
            routes.MapPageRoute("City1Route", "vacancies/" + HRTabs.GetCityTabLink(1, language), "~/City1.aspx");
            routes.MapPageRoute("City2Route", "vacancies/" + HRTabs.GetCityTabLink(2, language), "~/City2.aspx");
            routes.MapPageRoute("City3Route", "vacancies/" + HRTabs.GetCityTabLink(3, language), "~/City3.aspx");
            routes.MapPageRoute("City4Route", "vacancies/" + HRTabs.GetCityTabLink(4, language), "~/City4.aspx");
            routes.MapPageRoute("default", "vacancies/{language}", "~/City1.aspx");
        }    
