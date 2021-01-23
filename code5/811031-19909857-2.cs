            var query = from band in context.BandsEntitySet
                        //not sure the join makes sense. How come every band has a VenueName?
                        //join venue in context.VenueEntitySet 
                        //on band.VenueName equals venue.Name
                        //surely there should be a navigation property
                        from venue in band.Venues //using a navigation property
                        where band.ID == 12345
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
