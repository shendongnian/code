    private async void BtnShowRoute_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
                RouteQuery query = new RouteQuery();
                List<GeoCoordinate> wayPoints = new List<GeoCoordinate>();
    
                wayPoints.Add(new GeoCoordinate(47.23449, -121.172447));
                wayPoints.Add(new GeoCoordinate(47.062638, -120.691795));
    
                query.Waypoints = wayPoints;
       query .QueryCompleted += geoQ_QueryCompleted;
                query.GetRouteAsync();
    
           
        }  
     private void geoQ_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
            {
    
               
                try
                {
                    Route myRoute = e.Result;
                }
                catch (TargetInvocationException)
                {
                    Thread.Sleep(1000); // waiting for  completing the query
                        geoQ_QueryCompleted(sender, e);
                }
    
            }
