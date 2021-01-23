    string MostCommonName = vehicles
                            .OfType<Car>()
                            .GroupBy( c => c.Name , StringComparer.OrdinalIgnoreCase )
                            .OrderByDescending( g => g.Count() )
                            .ThenBy( g => g.Key )
                            .First()
                            .Select( g => g.Key )
                            ;
