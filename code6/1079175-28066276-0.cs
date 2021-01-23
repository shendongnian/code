            var minimumPrice = decimal.MaxValue;
            Itinerary minimumIteneray = null;
            foreach (var subreg in regions)
            {
                foreach (var itinerary in subreg.Itinerarys)
                {
                    var minimum = itinerary.ItineraryPackagePrices.Max(p => p.Price);
                    if (minimum < minimumPrice)
                    {
                        minimumPrice = minimum;
                        minimumIteneray = itinerary;
                    }
                }
            }
