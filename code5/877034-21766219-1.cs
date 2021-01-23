        void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("Mobile");
            routes.Ignore("Booking.aspx*");//<---- This Fixed it.
            routes.MapPageRoute("Gallery", "Gallery/{Name}", "~/Gallery.aspx");
            routes.Ignore("*");//<---- This is better for me. It acts as a catch all.
        }
