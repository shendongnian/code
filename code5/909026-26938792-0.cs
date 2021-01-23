    cars.GroupBy (car => new { car.Make, car.Model }, // Key selector for make and model as keys
                  vehicle => vehicle,                 // Element selector, we want all items of the original car instance which has the year
                  (key, vehicle) => new               // Result selector, we want to sum up the min/max year of vehicle.
                                    {
                                        Make  = key.Make,
                                        Model = key.Model,
                                        MinYear = vehicle.Min (car => car.Year),
                                        MaxYear = vehicle.Max (car => car.Year)
                                    }
                  );
