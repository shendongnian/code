    var vehicleList = (from v in context.Vehicles
                             select new
                             {
                                  Number = v.LicencePlateNumber,
                                  Make = v.Make,
                                  Model = v.Model,
                                  Year = v.PurchaseYear
                             }).ToList();
                        DG_Details.ItemsSource = vehicleList;
                        DG_Details.Items.Refresh();
