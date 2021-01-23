    var results = req.OrderByDescending(r => new[] { // Create a new array to hold the dates.
                    r.CreatedOn, // Start with the date of the Request
                    (r.Offers.Any() ? 
                        r.Offers.Select(o => o.CreatedOn).Max() : // If the Request has any Offers, get the max date of the offers.
                        DateTime.MinValue), // Otherwise add Min value so it won't affect the results.
                    (r.Offers.Any() ?
                        r.Offers.Select(o => o.Dialogs.Any() ? // If each Offer from each Request have any Dialogs
                            o.Dialogs.Select(d => d.CreatedOn).Max() : // Get the Max Dialog Date for each Offer
                            DateTime.MinValue) // Or put in a Min value for each Offer.
                        .Max() : // Then find the max for reach Offer's Dialogs (or Min Value for each Offer)
                        DateTime.MinValue) // If there are no Offers, again use Min value.
                  }.Max()) // Then get the Max from the 3 values in the array.
                  .Select(x => x).ToList();
