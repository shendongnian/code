     List<double> doubleList = new List<double>{
                    0.0015,
                    0.0016,
                    0.0017,
                    0.0019,
                    0.0021,
                    0.0022,
                    0.0029,
                    0.0030,
                    0.0033,
                    0.0036
                    };
        
                    double averageDistance = 0.0;
                    double totals = 0.0;
                    double distance = 0.0;
        
                    for (int x = 0; x < (doubleList.Count - 1); x++)
                    {
                        distance = doubleList[x] - doubleList[x + 1];
                        totals += Math.Abs(distance);
                    }
        
                    averageDistance = totals / doubleList.Count;
        
                    // check to see if any distance between numbers is more than the average in the list
                    for (int x = 0; x < (doubleList.Count - 1); x++)
                    {
                        distance = doubleList[x] - doubleList[x + 1];
                        if (distance > averageDistance)
                        {
                            // this is where you have a gap that you want to do some split (etc)
                        }
                    }
