     public ActionResult OverView(Position position)
            {
                 latitude = position.Latitude;
                 longitude = position.Longitude;
                 
                 //Passing the latitude and longitude values of last element in latitude and longitude lists
                 ViewBag.Latitude = latitude;
                 ViewBag.Longitude = longitude;
                 return View();
            }
