      var config = new MapperConfiguration(
        cfg =>
          {
            cfg.CreateMap<DsMyDataSet.TMyRow, MyRowDto>();
            cfg.ForAllMaps((typeMap, map) =>
              {
                map.ForAllMembers(opt =>
                  {
                    opt.PreCondition((src, context) =>
                      {
                        var row = src as DataRow;
                        if (row != null)
                        {
                          return !row.IsNull(opt.DestinationMember.Name);
                        }
                        return true;
                      });
                  });
              });
          });
