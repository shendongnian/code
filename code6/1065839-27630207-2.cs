    string MostCommonName = vehicles
                            .Where( v => v is Car )
                            .Cast<Car>()
                            .GroupBy( c => c.Name , StringComparer.OrdinalIgnoreCase )
                            .OrderByDescending( g => g.Count() )
                            .ThenBy( g => g.Key )
                            .First()
                            .Select( g => g.Key )
                            ;
