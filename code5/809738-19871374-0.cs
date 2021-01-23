            var route1 = new List<int> { 1, 2, 3 };
            var route2 = new List<int> { 6, 7, 8 };
            var route3 = new List<int> { 3, 7, 13 };
            var route4 = new List<int> { 8, 9, 10 };
            List<List<int>> routeList = new List<List<int>>();
            routeList.Add(route1);
            routeList.Add(route2);
            routeList.Add(route3);
            routeList.Add(route4);
            int startPoint = 2;
            int endPoint = 9;
            
            List<List<int>> finalRouteOrder = new List<List<int>>();
            //  Find starting route.
            List<int> currentRoute = routeList.Find(a => a.Contains(startPoint));
            //  Don't need that route in the list anymore.
            routeList.Remove(currentRoute);
            //  Add it to our final list of routes.
            finalRouteOrder.Add(currentRoute);
            bool done = false;
            while (!done)
            {
                foreach (int x in currentRoute)
                {
                    currentRoute = routeList.Find(a => a.Contains(x));
                    if (currentRoute != null)
                    {
                        finalRouteOrder.Add(currentRoute);  // add this route toi our final list of routes
                        routeList.Remove(currentRoute);  // remove that list since we are done with it.
                        
                        if (currentRoute.Contains(endPoint))
                        {
                            done = true;
                        }
                        break;
                    }
                    if (done)
                        break;
                   
                }
                if (done)
                    break;
            }
            //  finalRouteOrder contains the routes in order.
            MessageBox.Show("Done.");
