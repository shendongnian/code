    List<CustomDataset> cdList = 
                                  obj.Select(x => {
                                                   return new CustomDataset
                                                   {
                                                    from = x.Key,
                                                    cityId = x.Value.cityId,
                                                    cityName = x.Value.cityName,
                                                    cityCode =  x.Value.cityCode
                                                   }
                                                   } );
