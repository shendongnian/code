    List<CustomDataset> cdList = 
                                  obj.SelectMany(x => x.Value.Select(y =>
                                                   new CustomDataset
                                                   {
                                                    from = x.Key,
                                                    cityId = y.cityId,
                                                    cityName = y.cityName,
                                                    cityCode =  y.cityCode
                                                   }
                                                   )).ToList();
