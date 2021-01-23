            DBContext db = new DBContext();
            List<Instructor> instructors = db.Instructors.ToList();
            foreach (Instructor ins in instructors)
        	{
                routes.MapRoute(
                    name: "Instructor_" + ins.UserName,
                    url: ins.UserName,
                    defaults: new { controller = "People", action = "Details", id = ins.UserName }
                );
    	    }
        }
        public static void RefreshRouteTable()
        {
            // This method should be called when
            // 1) A new instructor is added
            // 2) An existing instructor is deleted
            // 3) Username of an existing instructor is changed.
            RouteTable.Routes.Clear();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
