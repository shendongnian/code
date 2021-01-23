            var query = from band in context.BandsEntitySet
                        from venue in context.VenueEntitySet
                        where band.ID == 12345 && venue != null
                        select new { 
                                       BandName = band.Name, 
                                       VenueName = venue.Name, 
                                       PlayDate = venue.PlayDate, 
                                       Address = venue.Address 
                                   };
            foreach (var item in query)
            {                
                Debug.WriteLine(item.BandName + " is playing in " 
                               + item.VenueName + " on the " + item.PlayDate);
                Debug.WriteLine("The address of " + item.VenueName + " is " + item.Address);
                
            }
