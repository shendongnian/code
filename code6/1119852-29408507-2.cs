     public ActionResult OverView(Position position)
            {
                 latitude = position.Latitude;
                 longitude = position.Longitude;
                 
                 //Passing the latitude and longitude values of last element in latitude and longitude lists
                 ViewBag.Latitude = latitude[latitude.Count-1];
                 ViewBag.Longitude = longitude[longitude.Count-1];
                 return View();
            }
