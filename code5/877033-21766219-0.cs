        void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("Mobile");
            routes.Ignore("Booking.aspx");//<---- This Fixed it.
            routes.MapPageRoute("Gallery", "Gallery/{Name}", "~/Gallery.aspx");
        }
